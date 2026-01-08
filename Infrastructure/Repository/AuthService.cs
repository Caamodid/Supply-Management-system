using Application.Common.Request;
using Application.Common.Response;
using Application.Common.Wrapper;
using Application.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Infrastructure.Repository
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly AppDbContext _context;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IJwtService jwtService,
            AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _context = context;
        }

        // ✅ LOGIN WITH REFRESH TOKEN
        public async Task<ResponseWrapper<LoginResponse>> LoginAsync(string usernameOrEmail, string password)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Email == usernameOrEmail || u.UserName == usernameOrEmail);

            if (user == null)
                return await ResponseWrapper<LoginResponse>.FailureAsync("Invalid username/email or password.");

            var valid = await _userManager.CheckPasswordAsync(user, password);
            if (!valid)
                return await ResponseWrapper<LoginResponse>.FailureAsync("Invalid username/email or password.");

            var roles = await _userManager.GetRolesAsync(user);
            var permissions = await _context.RolePermissions
                .Where(rp => roles.Contains(_roleManager.Roles.First(r => r.Id == rp.RoleId).Name))
                .Select(rp => rp.Permission)
                .ToListAsync();

            var token = await _jwtService.GenerateTokenAsync(user.Id, user.Email, roles, permissions);

            // ✅ refresh token rotation
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return await ResponseWrapper<LoginResponse>.SuccessAsync(new LoginResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                RefreshTokenExpiryDate = user.RefreshTokenExpiryDate
            }, "Login successful.");
        }

        // ✅ REFRESH TOKEN
        public async Task<ResponseWrapper<LoginResponse>> GetRefreshTokenAsync(RefreshTokenRequest request)
        {
            if (request is null || string.IsNullOrEmpty(request.Token) || string.IsNullOrEmpty(request.RefreshToken))
                return await ResponseWrapper<LoginResponse>.FailureAsync("Invalid client request.");

            var principal = GetPrincipalFromExpiredToken(request.Token);
            if (principal == null)
                return await ResponseWrapper<LoginResponse>.FailureAsync("Invalid access token.");

            var email = principal.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryDate <= DateTime.UtcNow)
                return await ResponseWrapper<LoginResponse>.FailureAsync("Invalid refresh token or expired.");

            var roles = await _userManager.GetRolesAsync(user);
            var permissions = await _context.RolePermissions
                .Where(rp => roles.Contains(_roleManager.Roles.First(r => r.Id == rp.RoleId).Name))
                .Select(rp => rp.Permission)
                .ToListAsync();

            var newJwt = await _jwtService.GenerateTokenAsync(user.Id, user.Email, roles, permissions);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return await ResponseWrapper<LoginResponse>.SuccessAsync(new LoginResponse
            {
                Token = newJwt,
                RefreshToken = newRefreshToken,
                RefreshTokenExpiryDate = user.RefreshTokenExpiryDate
            }, "Token refreshed.");
        }

        // ✅ Generate Refresh Token
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        // ✅ Extract Principal From Expired Token
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = _jwtService.GetValidationParametersForExpiredTokens();
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtToken)
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
