using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneHelper.Models;
using OneHelper.Dto;
using FluentValidation;
using OneHelper.Validators;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using OneHelper.Authorization.GoogleService;
using Microsoft.AspNetCore.Authentication;
using OneHelper.Authorization.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace OneHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController( ILogger<AuthController> logger, IValidator<RegisterDto> validator, 
        IAuthService<LoginDto,RegisterDto> service, IValidator<LoginDto> validatorLogin,
        IGoogleAuthService googleAuth) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly IValidator<RegisterDto> _validator = validator;
        private readonly IAuthService<LoginDto, RegisterDto> _accountService = service;
        private readonly IValidator<LoginDto> _validatorLogin = validatorLogin;
        private readonly IGoogleAuthService _googleAuthService = googleAuth;

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterDto dto)
        {
            try
            {
                var validation = await _validator.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors);
                }
                var result = await _accountService.Register(dto);
                return Ok(result.Succeeded ? result.Succeeded : result.Errors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var validation = await _validatorLogin.ValidateAsync(dto);
                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors);
                }
                var token = await _accountService.Login(dto);
                return Ok(token);
            }
            catch ( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Google")]
        [AllowAnonymous]
        public IActionResult GoogleLogin(string? returnUrl)
        {
            
            return new ChallengeResult("Google", new Microsoft.AspNetCore.Authentication.AuthenticationProperties
            {
               RedirectUri = Url.Action(nameof(GoogleCallbackAuth), new {redirectUrl = returnUrl})
            });
        }

        [HttpGet("GoogleCallback")]
        public async Task<IActionResult> GoogleCallbackAuth()
        {
            try
            {
                var test = await _googleAuthService.GetExternalLoginInfo();
                var context = await HttpContext.AuthenticateAsync("Google") ?? throw new Exception("Google context is null");
                
                if ( await _googleAuthService.Login(context) is string token && token is not null )
                {
                    Response.Cookies.Append("jwtauth", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                    });
                    return Ok();
                }
                throw new Exception("Login is not successful");
            }
            catch ( Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
