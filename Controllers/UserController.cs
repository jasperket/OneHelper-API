using Microsoft.AspNetCore.Mvc;
using OneHelper.Models;
using OneHelper.Repository.Interfaces;
using OneHelper.Dtos;

namespace OneHelper.Controllers
{
    [Route("OneHelper/[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepo.GetAllAsync();
                if (users == null)
                {
                    users = new List<User>();
                }
                else
                {
                    var userDto = users.Select(user => new UserResponse
                    (
                        user.Username,
                        user.Gender,
                        user.DateOfBirth,
                        user.Email,
                        user.FirstName,
                        user.LastName,
                        user.Height,
                        user.Weight
                    ));
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                throw new Exception("Get users error", ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserRegisterRequestDto user)
        {
            try
            {
                await _userRepo.AddAsync(new User
                {
                    Username = user.Username,
                    Password = user.Password,
                    Gender = user.Gender,
                    DateOfBirth = user.DOB,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Height = user.Height,
                    Weight = user.Weight
                });
                return Ok(user);
            }
            catch (Exception ex)
            {
                {
                    throw new Exception("User add error", ex);
                }
            }
        }
    }
}
