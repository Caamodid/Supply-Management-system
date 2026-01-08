export default function Dashboard() {
  return (
    <div className="min-h-screen bg-gray-50 p-6">
      {/* ✅ Header section */}
      <div className="bg-white p-6 rounded-lg shadow-sm border mb-6">
        <h1 className="text-3xl font-bold text-blue-700">
          Welcome to Dashboard
        </h1>
        <p className="text-gray-600 text-lg">
          You are logged in successfully 🎉
        </p>
      </div>

      {/* ✅ Example dashboard grid (expand later) */}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        <div className="bg-white p-5 rounded-lg shadow">
          <h2 className="text-lg font-semibold text-gray-700">Users</h2>
          <p className="text-gray-600 mt-2">Total: 245</p>
        </div>

        <div className="bg-white p-5 rounded-lg shadow">
          <h2 className="text-lg font-semibold text-gray-700">Roles</h2>
          <p className="text-gray-600 mt-2">Total: 12</p>
        </div>

        <div className="bg-white p-5 rounded-lg shadow">
          <h2 className="text-lg font-semibold text-gray-700">Settings</h2>
          <p className="text-gray-600 mt-2">Manage system preferences</p>
        </div>
      </div>
    </div>
  );
}
