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

        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ResponseWrapper<string>> CreateUserAsync(CreateUserRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true,
                Address = request.Address,
                PhoneNumber = request.Phone,
                FirstName = request.FullName,
                Gender = request.Gender,
                ProfilePictureUrl = request.ProfilePictureUrl,
                RefreshToken = "RefreshTokenExpiryTime"



            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return await ResponseWrapper<string>.FailureAsync(string.Join(", ", result.Errors.Select(e => e.Description)));

            return await ResponseWrapper<string>.SuccessAsync($"User '{request.Email}' created successfully");
        }

        public async Task<ResponseWrapper<string>> UpdateUserAsync(UpdateUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return await ResponseWrapper<string>.FailureAsync("User not found.");

            user.Email = request.Email;
            user.UserName = request.Email;
            user.FirstName = request.FullName;
            user.UserName =request.UserName;
            user.PhoneNumber =request.Phone;
            user.IsActive =request.Isactive;
            user.ProfilePictureUrl = request.ProfilePictureUrl;
            user.Gender = request.Gender;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded
                ? await ResponseWrapper<string>.SuccessAsync("User updated successfully.")
                : await ResponseWrapper<string>.FailureAsync("Failed to update user.");
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
