using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using OneHelper.Authorization.Interface;

namespace OneHelper.Authorization.GoogleService
{
    public interface IGoogleAuthService : IAuthService<AuthenticateResult, ExternalLoginInfo>
    {
        AuthenticationProperties ConfigureExternalLogin(string? redirectUrl);
        Task<ExternalLoginInfo?> GetExternalLoginInfo();
    }
}
