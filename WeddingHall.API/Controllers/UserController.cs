using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.DTOs.SignIn;
using WeddingHall.Application.DTOs.UserRegistration;
using WeddingHall.Application.Interfaces;

namespace WeddingHall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; //from (interfaces)
        public UserController(IUserService userService) //constructor 
        {
            _userService = userService;
        }

        //POST/api/User/register 
        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody]UserRegistrationRequest request)// from (DTOs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.RegisterUserAsync(request);
            if (!result)
            {
                return BadRequest(new
                {
                    success = false,
                    message= "EMAIL ALREADY EXSISTS!"

                });

            }
            return Ok(new 
            {
                success= true,
                message= "USER SUCCESSFULLY REGISTERED!"

            });



        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var result = await _userService.SignInAsync(request);

            if (result == null)
                return Unauthorized("Invalid email or password");

            return Ok(result);
        }

    }
}
