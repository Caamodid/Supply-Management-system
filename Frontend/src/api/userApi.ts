import axiosClient from "./axiosClient";

//  Create user (requires Roles.Manage permission)
export const createUser = async (data: any) => {
  const response = await axiosClient.post("/user/create", data);
  return response.data;
};

//  Update user (requires Roles.Edit permission)
export const updateUser = async (data: any) => {
  const response = await axiosClient.put("/user/edit", data);
  return response.data;
};

//  Delete user (requires Roles.Manage)
export const deleteUser = async (userId: string) => {
  const response = await axiosClient.delete(`/user/delete/${userId}`);
  return response.data;
};

//  ✅ Get all users (requires Roles.Create permission)
export const getAllUsers = async (config?: any) => {
  const response = await axiosClient.get("/user/all", config);
  return response.data;
};

//  Change password (authenticated)
export const changePassword = async (data: any) => {
  const response = await axiosClient.post("/user/change-password", data);
  return response.data;
};

//  Reset password (public)
export const resetPassword = async (data: any) => {
  const response = await axiosClient.post("/user/reset-password", data);
  return response.data;
};

