using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        // 🔹 Personal Information
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string RefreshToken { get; set; } = "MyTokenFirstIniatal";
        public DateTime RefreshTokenExpiryDate { get; set; }
        public Guid? BranchId { get; set; } // NULL = global category


        public string Gender { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }

        // 🔹 Contact & Address
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;

        // 🔹 System / Status
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string? CreatedBy { get; set; }


    }
}
