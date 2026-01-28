using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserService : IUserService
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICurrentUserService _currentUser;
        private readonly ISalesService  _salesService;
        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, ICurrentUserService  currentUserService , ISalesService  salesService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _currentUser = currentUserService;
            _salesService = salesService;
        }

        public async Task<ResponseWrapper<string>> CreateUserAsync(CreateUserRequest request)
        {

            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true,
                Address = request.Address,
                PhoneNumber = request.Phone,
                FirstName = request.FullName,
                Gender = request.Gender,
                BranchId = request.BranchId,

                CreatedAt = DateTime.UtcNow,
                CreatedBy = _currentUser.UserId, // or UserId

                ProfilePictureUrl = "Url",
                RefreshToken = "RefreshToken"
            };

            // 1️⃣ Create User
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return await ResponseWrapper<string>.FailureAsync(
                    string.Join(", ", result.Errors.Select(e => e.Description))
                );
            }

            // 2️⃣ Assign Role
            if (!string.IsNullOrWhiteSpace(request.Role))
            {
                if (!await _roleManager.RoleExistsAsync(request.Role))
                {
                    return await ResponseWrapper<string>.FailureAsync($"Role '{request.Role}' does not exist");
                }

                var roleResult = await _userManager.AddToRoleAsync(user, request.Role);

                if (!roleResult.Succeeded)
                {
                    return await ResponseWrapper<string>.FailureAsync(
                        string.Join(", ", roleResult.Errors.Select(e => e.Description))
                    );
                }
            }

            return await ResponseWrapper<string>.SuccessAsync(
                $"User '{request.Email}' created successfully with role '{request.Role}'"
            );
        }


        public async Task<ResponseWrapper<string>> UpdateUserAsync(UpdateUserRequest request)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return await ResponseWrapper<string>.FailureAsync("User not found.");

            /* ---------- Update Basic Info ---------- */
            user.Email = request.Email;
            user.UserName = request.UserName;
            user.FirstName = request.FullName;
            user.PhoneNumber = request.Phone;
            user.Gender = request.Gender;
            user.BranchId = request.BranchId;
            user.UpdatedAt = DateTime.UtcNow;
            user.CreatedBy = _currentUser.UserId; // or UserId
           

            /* ---------- Update User ---------- */
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return await ResponseWrapper<string>.FailureAsync(
                    string.Join(", ", updateResult.Errors.Select(e => e.Description))
                );
            }

            /* ---------- Update Role (Optional) ---------- */
            if (!string.IsNullOrWhiteSpace(request.Role))
            {
                var currentRoles = await _userManager.GetRolesAsync(user);

                if (currentRoles.Any())
                {
                    var removeRolesResult =
                        await _userManager.RemoveFromRolesAsync(user, currentRoles);

                    if (!removeRolesResult.Succeeded)
                    {
                        return await ResponseWrapper<string>.FailureAsync(
                            "Failed to remove existing roles."
                        );
                    }
                }

                if (!await _roleManager.RoleExistsAsync(request.Role))
                    return await ResponseWrapper<string>.FailureAsync("Role does not exist.");

                var addRoleResult =
                    await _userManager.AddToRoleAsync(user, request.Role);

                if (!addRoleResult.Succeeded)
                {
                    return await ResponseWrapper<string>.FailureAsync(
                        "Failed to assign new role."
                    );
                }
            }

            /* ---------- Update Password (Optional) ---------- */
            if (!string.IsNullOrWhiteSpace(request.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult =
                    await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

                if (!passwordResult.Succeeded)
                {
                    return await ResponseWrapper<string>.FailureAsync(
                        string.Join(", ", passwordResult.Errors.Select(e => e.Description))
                    );
                }
            }

            return await ResponseWrapper<string>.SuccessAsync("User updated successfully.");
        }

        public async Task<ResponseWrapper<string>> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return await ResponseWrapper<string>.FailureAsync("User not found.");

            var result = await _userManager.DeleteAsync(user);

            return result.Succeeded
                ? await ResponseWrapper<string>.SuccessAsync("User deleted successfully.")
                : await ResponseWrapper<string>.FailureAsync("Failed to delete user.");
        }

        public async Task<ResponseWrapper<string>> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return await ResponseWrapper<string>.FailureAsync("User not found.");

            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

            return result.Succeeded
                ? await ResponseWrapper<string>.SuccessAsync("Password changed successfully.")
                : await ResponseWrapper<string>.FailureAsync("Failed to change password.");
        }

        public async Task<ResponseWrapper<string>> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return await ResponseWrapper<string>.FailureAsync("User not found.");

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

            return result.Succeeded
                ? await ResponseWrapper<string>.SuccessAsync("Password reset successfully.")
                : await ResponseWrapper<string>.FailureAsync("Failed to reset password.");
        }

        public async Task<ResponseWrapper<string>> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return await ResponseWrapper<string>.FailureAsync("User not found.");

            var result = await _userManager.ConfirmEmailAsync(user, token);

            return result.Succeeded
                ? await ResponseWrapper<string>.SuccessAsync("Email confirmed successfully.")
                : await ResponseWrapper<string>.FailureAsync("Failed to confirm email.");
        }



        public async Task<List<UserResponses>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = new List<UserResponses>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                result.Add(new UserResponses
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Isactive = user.IsActive,
                    Gender = user.Gender,
                    FullName = user.FirstName,
                    Address = user.Address,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    Role = roles.Any()
                        ? string.Join(", ", roles)
                        : "No Role"
                });
            }

            return result;
        }


    }
}
