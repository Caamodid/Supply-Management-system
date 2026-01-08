import { useState } from "react";
import Sidebar from "./Sidebar";
import Navbar from "./Navbar";
import { Outlet } from "react-router-dom";

export default function MainLayout() {
  const [sidebarOpen, setSidebarOpen] = useState(false);

  return (
    <div className="flex min-h-screen bg-gray-100">
      {/* ✅ Sidebar fixed */}
      <aside className="fixed top-0 left-0 h-full w-64 bg-white shadow-md z-40">
        <Sidebar
          isOpen={sidebarOpen}
          toggle={() => setSidebarOpen(!sidebarOpen)}
        />
      </aside>

      {/* ✅ Main content (fills remaining space) */}
      <div className="flex flex-col flex-1 ml-64">
        {/* Navbar aligned correctly */}
        <Navbar onMenuClick={() => setSidebarOpen(!sidebarOpen)} />

        {/* Scrollable content area */}
        <main className="flex-1 p-6 overflow-y-auto bg-gray-100">
          <Outlet />
        </main>
      </div>
    </div>
  );
}
