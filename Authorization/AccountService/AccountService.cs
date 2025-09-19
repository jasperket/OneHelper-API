using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OneHelper.Authorization.Interface;
using OneHelper.Dto;
using OneHelper.Models;
using OneHelper.Services.TokenService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OneHelper.Authorization.AccountService
{
    public class AccountService(UserManager<User> userManager, IMapper mapper, ITokenService service) : IAccountService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IMapper _mapper = mapper;
        private readonly ITokenService _tokenService = service;
        public virtual async Task<string?> Login(LoginDto data)
        {

            if (await _userManager.FindByNameAsync(data.LoginInformation) is User username && username is not null)
            {
                if (await _userManager.CheckPasswordAsync(username, data.Password))
                {
                    return _tokenService.GenerateToken(username);
                }
            }

            if (await _userManager.FindByEmailAsync(data.LoginInformation) is User email && email is not null)
            {
                if (await _userManager.CheckPasswordAsync(email, data.Password))
                {
                    return _tokenService.GenerateToken(email);
                }
            }
            throw new Exception("Login information is invalid");
        }

        public virtual bool Logout(string? token)
        {
            if ( token is null )
            {
                return false;
            }
            return true;
        }

        public virtual async Task<IdentityResult> Register(RegisterDto data)
        {
            try
            {
                var entity = _mapper.Map<User>(data);
                var result = await _userManager.CreateAsync(entity, data.Password);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
