import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "../../features/auth/pages/Login";
import Dashboard from "../../features/dashboard/Dashboard";
import UserList from "../../features/auth/pages/UserList";
import MainLayout from "../../layout/MainLayout"; //  Import your layout

export default function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        {/* 🟢 Public Route */}
        <Route path="/login" element={<Login />} />

        {/* 🔒 Protected Routes under MainLayout */}
        <Route element={<MainLayout />}>
          <Route path="/" element={<Dashboard />} />
          <Route path="/users" element={<UserList />} />
          {/* Add more pages below */}
          {/* <Route path="/roles" element={<RoleList />} /> */}
          {/* <Route path="/settings" element={<Settings />} /> */}
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
