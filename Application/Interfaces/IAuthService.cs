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
    public interface IAuthService
    {
        Task<ResponseWrapper<LoginResponse>> LoginAsync(string usernameOrEmail, string password);
        Task<ResponseWrapper<LoginResponse>> GetRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);

    }
}
