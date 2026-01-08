import { useState } from "react";
import { loginUser } from "../../../api/authApi";
import toast from "react-hot-toast";
export default function Login() {
  const [form, setForm] = useState({ UsernameOrEmail: "", Password: "" });
  const [loading, setLoading] = useState(false);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      const res = await loginUser(form);

      if (res.success) {
        toast.success(res.message || "Login successful!");
        const token = res.data?.token || res.token;
        if (token) localStorage.setItem("token", token);
        window.location.href = "/";
      } else {
        toast.error(res.message || "Login failed");
      }
    } catch (err: any) {
      const backendMsg =
        err?.message ||
        err?.title ||
        Object.values(err?.errors || {}).flat().join(", ") ||
        "Login failed";
      toast.error(backendMsg);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100">
      <form
        onSubmit={handleSubmit}
        className="bg-white shadow-lg p-8 rounded-md w-96 space-y-4"
      >
        <h2 className="text-2xl font-bold text-center text-gray-700">Login</h2>

        <input
          type="text"
          name="UsernameOrEmail"
          placeholder="Username or Email"
          value={form.UsernameOrEmail}
          onChange={handleChange}
          className="w-full p-2 border rounded focus:outline-blue-500"
          required
        />

        <input
          type="password"
          name="Password"
          placeholder="Password"
          value={form.Password}
          onChange={handleChange}
          className="w-full p-2 border rounded focus:outline-blue-500"
          required
        />

        <button
          type="submit"
          disabled={loading}
          className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
        >
          {loading ? "Logging in..." : "Login"}
        </button>
      </form>
    </div>
  );
}
