import { Menu } from "lucide-react";

interface NavbarProps {
  onMenuClick: () => void;
}

export default function Navbar({ onMenuClick }: NavbarProps) {
  const handleLogout = () => {
    localStorage.removeItem("token");
    window.location.href = "/login";
  };

  return (
    <header className="w-full bg-white shadow px-6 py-3 flex justify-between items-center sticky top-0 z-50">
      <div className="flex items-center space-x-2">
        {/* Hamburger for mobile */}
        <button
          onClick={onMenuClick}
          className="md:hidden text-gray-700 hover:text-gray-900"
        >
          <Menu size={22} />
        </button>

        <h1 className="text-lg font-semibold text-gray-800">
          Enterprise Systems
        </h1>
        <span className="ml-2 text-gray-600">Welcome 👋</span>
      </div>

      <button
        onClick={handleLogout}
        className="bg-red-500 text-white px-4 py-1 rounded-md hover:bg-red-600"
      >
        Logout
      </button>
    </header>
  );
}
