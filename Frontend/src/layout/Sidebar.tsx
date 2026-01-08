// src/layout/Sidebar.tsx
import { NavLink } from "react-router-dom";
import { Users, Shield, Settings, X } from "lucide-react";

interface SidebarProps {
  isOpen: boolean;
  toggle: () => void;
}

export default function Sidebar({ isOpen, toggle }: SidebarProps) {
  return (
    <>
      {/* Overlay for mobile */}
      {isOpen && (
        <div
          onClick={toggle}
          className="fixed inset-0 bg-black bg-opacity-30 z-30 md:hidden"
        ></div>
      )}

      <aside
        className={`fixed z-40 inset-y-0 left-0 bg-white shadow-lg w-64 transform transition-transform duration-300 md:translate-x-0 
        ${isOpen ? "translate-x-0" : "-translate-x-full"}`}
      >
        <div className="p-4 flex items-center justify-between border-b">
          <h2 className="text-lg font-bold text-gray-800">Menu</h2>
          <button
            onClick={toggle}
            className="md:hidden text-gray-600 hover:text-gray-900"
          >
            <X size={22} />
          </button>
        </div>

        <nav className="p-4 space-y-2">
          <NavLink
            to="/users"
            className={({ isActive }) =>
              `flex items-center p-2 rounded-md ${
                isActive
                  ? "bg-blue-100 text-blue-700 font-semibold"
                  : "text-gray-700 hover:bg-gray-100"
              }`
            }
          >
            <Users className="mr-2" size={18} /> Users
          </NavLink>

          <NavLink
            to="/roles"
            className={({ isActive }) =>
              `flex items-center p-2 rounded-md ${
                isActive
                  ? "bg-blue-100 text-blue-700 font-semibold"
                  : "text-gray-700 hover:bg-gray-100"
              }`
            }
          >
            <Shield className="mr-2" size={18} /> Roles
          </NavLink>

          <NavLink
            to="/settings"
            className={({ isActive }) =>
              `flex items-center p-2 rounded-md ${
                isActive
                  ? "bg-blue-100 text-blue-700 font-semibold"
                  : "text-gray-700 hover:bg-gray-100"
              }`
            }
          >
            <Settings className="mr-2" size={18} /> Settings
          </NavLink>
        </nav>
      </aside>
    </>
  );
}
