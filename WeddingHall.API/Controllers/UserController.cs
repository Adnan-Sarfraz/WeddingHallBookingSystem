using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.Common;
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
 
        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody]UserRegistrationRequest request)// from (DTOs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<object>.FailureResponse("Invalid request data"));
            }
            var result = await _userService.RegisterUserAsync(request);
            if (!result)
            {
                return BadRequest(ApiResponse<bool>.FailureResponse("Email already exists"));

            }
            return Ok(ApiResponse<bool>.SuccessResponse(true, "User registered successfully"));

        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var result = await _userService.SignInAsync(request);

            if (result == null)
            {
                return Unauthorized(ApiResponse<object>.FailureResponse("Invalid email or password"));
            }

            return Ok(ApiResponse<object>.SuccessResponse(result, "User signed in successfully"));
        }

    }
}
