using Microsoft.IdentityModel.Tokens;
using OneHelper.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OneHelper.Services.TokenService
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        private readonly IConfiguration _config = config;
        public string? GenerateToken(User user)
        {
            var secret = _config["JwtConfig:Secret"];
            var issuer = _config["JwtConfig:ValidIssuer"];
            var audiences = _config["JwtConfig:ValidAudiences"];

            if (secret is null || issuer is null || audiences is null)
            {
                throw new ApplicationException("Jwt is not set correctly in the configuration");
            }

            var loginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = issuer,
                Audience = audiences,
                SigningCredentials = new SigningCredentials(loginKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
