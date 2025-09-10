using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OneHelper.Dto;
using OneHelper.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OneHelper.Services.AuthService
{
    public class AccountService(UserManager<User> userManager, IConfiguration config, IMapper mapper) : IAccountService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IConfiguration _config = config;
        private readonly IMapper _mapper = mapper;
        public async Task<string?> Login(LoginDto dto)
        {
            if (await _userManager.FindByNameAsync(dto.LoginInformation) is User username && username is not null)
            {
                if (await _userManager.CheckPasswordAsync(username, dto.Password))
                {
                    return GenerateToken(username);
                }
            }

            if (await _userManager.FindByEmailAsync(dto.LoginInformation) is User email && email is not null)
            {
                if (await _userManager.CheckPasswordAsync(email, dto.Password))
                {
                    return GenerateToken(email);
                }
            }
            
            throw new Exception("Login information is invalid");
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> Register(RegisterDto dto)
        {
            try
            {
                var entity = _mapper.Map<User>(dto);
                var result = await _userManager.CreateAsync(entity, dto.Password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private string? GenerateToken(User user)
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
