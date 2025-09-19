using Microsoft.AspNetCore.Identity;
using OneHelper.Dto;

namespace OneHelper.Authorization.Interface
{
    public interface IAuthService<TLoginIdentityObject, TRegisterIdentityObject> 
        where TLoginIdentityObject : class
        where TRegisterIdentityObject : class
    {
        Task<string?> Login(TLoginIdentityObject data);
        Task<IdentityResult> Register(TRegisterIdentityObject data);
        bool Logout(string? token);
    }
}
