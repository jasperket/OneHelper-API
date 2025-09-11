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
using OneHelper.Services.AuthService;

namespace OneHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController( ILogger<AuthController> logger, IValidator<RegisterDto> validator, 
        IAccountService service, IValidator<LoginDto> validatorLogin) : ControllerBase
    {
        private readonly ILogger<AuthController> _logger = logger;
        private readonly IValidator<RegisterDto> _validator = validator;
        private readonly IAccountService _accountService = service;
        private readonly IValidator<LoginDto> _validatorLogin = validatorLogin;

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
    }
}
