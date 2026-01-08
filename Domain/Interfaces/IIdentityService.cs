using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> RoleExistsAsync(string roleName);
        Task<bool> AddUserToRoleAsync(string userId, string roleName);
        Task<IList<string>> GetUserRolesAsync(string email);
        Task<bool> RemoveUserFromRoleAsync(string userId, string roleName);
        Task<List<RoleWithCreatorDto>> GetAllRolesAsync();
        Task<bool> CreateRoleAsync(string name, string? description);

        Task<bool> UpdateRoleAsync(string roleId, string name, string? description);





    }
}
