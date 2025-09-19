using Microsoft.AspNetCore.Identity;
using OneHelper.Authorization.Interface;
using OneHelper.Dto;
using OneHelper.Models;

namespace OneHelper.Authorization.AccountService
{
    public interface IAccountService : IAuthService<LoginDto, RegisterDto>
    {
    }
}
