using OneHelper.Models;

namespace OneHelper.Services.TokenService
{
    public interface ITokenService
    {
        string? GenerateToken(User user);
    }
}
