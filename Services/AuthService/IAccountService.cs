using Microsoft.AspNetCore.Identity;
using OneHelper.Dto;
using OneHelper.Models;

namespace OneHelper.Services.AuthService
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterDto dto);
        Task<string?> Login(LoginDto dto);
        Task<bool> Logout();
    }
}
