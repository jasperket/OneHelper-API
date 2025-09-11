using Microsoft.AspNetCore.Mvc;
using OneHelper.Models;
using OneHelper.Repository.Interfaces;
/*
namespace OneHelper.Controllers
{
    
    [Route("OneHelper/[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo) {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepo.GetAllAsync();
                if ( users == null )
                {
                    users = new List<User>();
                }
                return Ok(users);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error Occurred");
            }
        }
    }
}
    */