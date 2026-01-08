import axiosClient from "./axiosClient";

export interface LoginRequest {
  UsernameOrEmail: string;
  Password: string;
}

export interface LoginResponse {
  success: boolean;
  message: string;
  token?: string;
  data?: {
    token?: string;
  };
}

export const loginUser = async (data: LoginRequest): Promise<LoginResponse> => {
  //console.log("📤 Sending login request:", data);

  try {
    const response = await axiosClient.post("/user/login", data, {
      headers: {
        "Content-Type": "application/json",
      },
    });

    //console.log("✅ Login response:", response.data);
    return response.data; // directly return backend JSON
  } catch (error: any) {
    if (error.response) {
      //console.error("❌ Backend responded with error:", error.response.data);
      throw error.response.data; // throw backend message forward
    } else if (error.request) {
      //console.error("⚠️ No response from backend:", error.request);
      throw new Error("No response from backend");
    } else {
      //console.error("💥 Error setting up request:", error.message);
      throw new Error(error.message);
    }
  }
};
