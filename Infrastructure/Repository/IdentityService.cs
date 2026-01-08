using Application.Common.Request;
using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICurrentUserService _currentUser;
        private readonly AppDbContext _context;



        public IdentityService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager , ICurrentUserService currentUser , AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _currentUser = currentUser;
            _context = context;
        }

        public async Task<bool> RoleExistsAsync(string roleName)
            => await _roleManager.RoleExistsAsync(roleName);

        public async Task<bool> AddUserToRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }


        public async Task<bool> CreateRoleAsync(string name, string? description)
        {
            // 🔐 Auth check
            if (string.IsNullOrWhiteSpace(_currentUser.UserId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            // 🧪 Validation
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Role name is required.");

            var normalizedName = name.Trim().ToUpperInvariant();

            // ❌ Prevent duplicate roles
            var exists = await _roleManager.Roles
                .AnyAsync(r => r.NormalizedName == normalizedName);

            if (exists)
                throw new InvalidOperationException("Role already exists.");

            var role = new ApplicationRole
            {
                Name = name.Trim(),
                NormalizedName = normalizedName,
                Description = description,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = _currentUser.UserId,
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                var errors = string.Join(" | ",
                    result.Errors.Select(e => $"{e.Code}: {e.Description}")
                );

                throw new InvalidOperationException(errors);
            }

            return true;
        }



        public async Task<IList<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user != null ? await _userManager.GetRolesAsync(user) : new List<string>();
        }

        public async Task<bool> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;
        }


        public async Task<List<RoleWithCreatorDto>> GetAllRolesAsync()
        {
            return await (
                from role in _roleManager.Roles
                join user in _context.Users
                    on role.CreatedBy equals user.Id into users
                from createdUser in users.DefaultIfEmpty()
                select new RoleWithCreatorDto
                {
                    Id = role.Id,
                    Name = role.Name!,
                    Description = role.Description,
                    CreatedAt = role.CreatedAt,
                    CreatedByUserName = createdUser != null ? createdUser.UserName : null
                }
            ).ToListAsync();
        }


        public async Task<bool> UpdateRoleAsync(string roleId, string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(_currentUser.UserId))
                throw new UnauthorizedAccessException();

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                throw new KeyNotFoundException("Role not found");

            var trimmedName = name.Trim();

            role.Name = trimmedName;
            role.NormalizedName = trimmedName.ToUpperInvariant(); // ✅ REQUIRED
            role.Description = description;

            // ✅ Audit fields
            role.UpdatedAt = DateTime.UtcNow;
            role.UpdatedBy = _currentUser.UserId;

            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                // Identity already gives correct message like:
                // "Role name 'Manager' is already taken."
                throw new InvalidOperationException(
                    string.Join(", ", result.Errors.Select(e => e.Description))
                );
            }

            return true;
        }



    }
}
