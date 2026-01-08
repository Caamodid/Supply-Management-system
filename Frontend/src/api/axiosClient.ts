import axios from "axios";
import toast from "react-hot-toast";
import type {
  AxiosError,
  AxiosInstance,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from "axios";

// ✅ Create axios instance
const axiosClient: AxiosInstance = axios.create({
  baseURL: "http://localhost:5120/api", // change if deployed
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
  withCredentials: false,
});

// ✅ Request interceptor – automatically attach JWT
axiosClient.interceptors.request.use(
  (config: InternalAxiosRequestConfig) => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers = config.headers ?? {};
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    console.error("❌ Request error:", error);
    return Promise.reject(error);
  }
);

// ✅ Response interceptor – global success/error handling
axiosClient.interceptors.response.use(
  (response: AxiosResponse) => {
    return response;
  },
  (error: AxiosError<any>) => {
    if (error.response) {
      const status = error.response.status;
      const backendMessage =
        (error.response.data?.message as string) ||
        (error.response.data?.title as string) ||
        Object.values(error.response.data?.errors || {}).flat().join(", ") ||
        null;

      // 🔒 Unauthorized (token invalid or expired)
      if (status === 401) {
        toast.error("Session expired. Please log in again.");
        localStorage.removeItem("token");
        window.location.href = "/login";
      }

      // 🚫 Forbidden (no permission)
      else if (status === 403) {
        toast.error(backendMessage || "Access denied. You don't have permission.");
      }

      // ⚠️ Client validation (400)
      else if (status === 400) {
        toast.error(backendMessage || "Invalid request. Please check your input.");
      }

      // 💥 Server error (500+)
      else if (status >= 500) {
        toast.error("Internal server error. Please try again later.");
        console.error("💥 Server error:", error.response);
      }
    } else {
      // 🌐 Network or connection issue
      console.error("🌐 Network error:", error.message);
      toast.error("Network error. Please check your connection.");
    }

    return Promise.reject(error);
  }
);

export default axiosClient;
