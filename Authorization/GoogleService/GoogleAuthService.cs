using Microsoft.AspNetCore.Identity;
using OneHelper.Models;
using AutoMapper;
using OneHelper.Services.TokenService;
using OneHelper.Dto;
using OneHelper.Authorization.AccountService;
using System.Security.Claims;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authentication;

namespace OneHelper.Authorization.GoogleService
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signinManager;
        private readonly string _google = "Google";
        public GoogleAuthService(UserManager<User> manager, IMapper mapper, ITokenService token, SignInManager<User> signinManager)
        {
            _userManager = manager;
            _mapper = mapper;
            _tokenService = token;
            _signinManager = signinManager;
        }

        public async Task<string?> Login(AuthenticateResult data)
        {

            if ( data is null || data.Principal is null)
            {
                throw new Exception("Google data context is null");
            }
            var providerKey = data.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var displayName = data.Principal.FindFirstValue(ClaimTypes.Name);
            
            var externalInfo = new ExternalLoginInfo(data.Principal, _google, providerKey!, displayName!);
            var registerResult = await Register(externalInfo);
            if ( registerResult.Succeeded )
            {
                var email = data.Principal.FindFirstValue(ClaimTypes.Email);
                var result = await _userManager.FindByEmailAsync(email!) ?? throw new Exception("User is not found");
                return _tokenService.GenerateToken(result);
            }
            throw new Exception("Login unsuccessful");
        }

        public AuthenticationProperties ConfigureExternalLogin(string? redirectUrl) =>  _signinManager
                                            .ConfigureExternalAuthenticationProperties("Google", redirectUrl);

        public async Task<ExternalLoginInfo?> GetExternalLoginInfo() => await _signinManager.GetExternalLoginInfoAsync();

        public bool Logout(string? token)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> Register(ExternalLoginInfo data)
        {
            var user = await _userManager.FindByEmailAsync(data.Principal.FindFirstValue(ClaimTypes.Email) ??
                throw new Exception("Email is null"));
            
            var date = DateOnly.FromDateTime(DateTime.Parse(data.Principal.FindFirstValue(ClaimTypes.DateOfBirth) ?? DateTime.Now.ToString()));
            if ( user is not null )
            {
                var loginAsync = await _userManager.AddLoginAsync(user, data);
                if ( loginAsync.Succeeded )
                {
                    await _userManager.UpdateAsync(user);
                    return loginAsync;
                }
            }
            var createUser = await _userManager.CreateAsync(new User
            {
                UserName = data.Principal.FindFirstValue(ClaimTypes.Email) ?? string.Empty,
                FirstName = data.Principal.FindFirstValue(ClaimTypes.GivenName) ?? string.Empty,
                LastName = data.Principal.FindFirstValue(ClaimTypes.Surname) ?? string.Empty,
                Email = data.Principal.FindFirstValue(ClaimTypes.Email) ?? string.Empty,
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
                Gender = "Male"
            });

            var userSearch = data.Principal.FindFirstValue(ClaimTypes.Email) ?? throw new Exception("Email is null");
            var userFind = await _userManager.FindByEmailAsync(userSearch) ?? throw new Exception("User not found.. unsuccessful login");
            await _userManager.AddLoginAsync(userFind, data);
            return createUser;
        }
    }
}
