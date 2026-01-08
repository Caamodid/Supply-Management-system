using System;

namespace Application.Common.Request
{
    // 🔹 Create User
    public class CreateUserRequest
    {
        public string Password { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public bool Isactive { get; set; } = true;
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;


    }

    // 🔹 Update User
    public class UpdateUserRequest
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public bool Isactive { get; set; } = true;
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;

    }

    // 🔹 Change Password
    public class ChangePasswordRequest
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    // 🔹 Reset Password
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
