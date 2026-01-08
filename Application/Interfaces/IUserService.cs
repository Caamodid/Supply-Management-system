using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {

        // 🔹 New Methods
        Task<ResponseWrapper<string>> CreateUserAsync(CreateUserRequest request);
        Task<ResponseWrapper<string>> UpdateUserAsync(UpdateUserRequest request);
        Task<ResponseWrapper<string>> DeleteUserAsync(string userId);
        Task<ResponseWrapper<string>> ChangePasswordAsync(ChangePasswordRequest request);
        Task<ResponseWrapper<string>> ResetPasswordAsync(ResetPasswordRequest request);
        Task<ResponseWrapper<string>> ConfirmEmailAsync(string userId, string token);
        Task<List<UserResponses>> GetAllUsersAsync();
    }
}
