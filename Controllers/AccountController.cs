using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneHelper.Dto;
using OneHelper.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace OneHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IValidator<RegisterDto> _validator;
        public AccountController(UserManager<User> userManager, IValidator<RegisterDto> validator)
        {
            _userManager = userManager;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var validation = await _validator.ValidateAsync(registerDto);
            if ( !validation.IsValid)
            {
                return BadRequest();
            }

            var registerOperation = await _userManager.CreateAsync(new User
            {
                UserName = registerDto.Username,
                Gender = registerDto.Gender,
                DateOfBirth = registerDto.DateOfBirth,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Height = registerDto.Height,   
                Weight = registerDto.Weight
            }, registerDto.Password);

            if ( registerOperation.Succeeded)
            {
                return Ok("Successful Registration");
            }
            return BadRequest(registerOperation.Errors);
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.username);
            if ( user != null && await _userManager.CheckPasswordAsync(user, dto.password))
            {
                await SignInAsync(user);
                return Ok("User logged in");
            }
            return Unauthorized(new {messsage = "Invalid login"});
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Succesfully logout");
        }

        private async Task SignInAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
