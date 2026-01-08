import { useEffect, useState } from "react";
import toast from "react-hot-toast";
import { getAllUsers } from "../../../api/userApi";

interface User {
  id: string;
  username: string;
  email: string;
  role: string;
}

export default function UserList() {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const controller = new AbortController();

    const fetchUsers = async () => {
      try {
        const res = await getAllUsers({ signal: controller.signal });
        if (res.success) {
          setUsers(res.data ?? []);
          toast.success(res.message ?? "✅ Users loaded successfully!");
        } else {
          toast.error(res.message ?? "❌ Failed to load users.");
        }
      } catch (err: any) {
        if (err.name === "AbortError") return;
        const backendMsg =
          err?.response?.data?.message ||
          err?.message ||
          Object.values(err?.errors || {}).flat().join(", ") ||
          "Failed to fetch users";
        toast.error(backendMsg);
      } finally {
        setLoading(false);
      }
    };

    fetchUsers();
    return () => controller.abort();
  }, []);

  if (loading) {
    return (
      <div className="flex justify-center items-center h-64">
        <div className="animate-spin rounded-full h-10 w-10 border-t-4 border-blue-500"></div>
      </div>
    );
  }

  return (
    <section className="mt-8 px-4 sm:px-6 lg:px-8">
      {/* ✅ Title */}
      <div className="bg-white p-6 rounded-lg shadow border mb-6">
        <h2 className="text-2xl font-semibold text-gray-800 flex items-center gap-2">
          👥 User List
        </h2>
      </div>

      {/* ✅ Table */}
      <div className="bg-white p-6 rounded-lg shadow border overflow-x-auto">
        <table className="min-w-full border border-gray-200 text-sm text-gray-700">
          <thead>
            <tr className="bg-gray-100 text-left">
              <th className="p-3 border w-12 text-center">#</th>
              <th className="p-3 border">Username</th>
              <th className="p-3 border">Email</th>
              <th className="p-3 border text-center">Role</th>
            </tr>
          </thead>

          <tbody>
            {users.length > 0 ? (
              users.map((u, i) => (
                <tr
                  key={u.id}
                  className="hover:bg-gray-50 transition-colors duration-150"
                >
                  <td className="p-3 border text-center">{i + 1}</td>
                  <td className="p-3 border">{u.username}</td>
                  <td className="p-3 border">{u.email}</td>
                  <td className="p-3 border text-center">
                    <span className="bg-blue-100 text-blue-700 px-3 py-1 rounded-full text-xs sm:text-sm font-medium">
                      {u.role}
                    </span>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td
                  colSpan={4}
                  className="p-6 text-center text-gray-500 italic"
                >
                  No users found.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </section>
  );
}
