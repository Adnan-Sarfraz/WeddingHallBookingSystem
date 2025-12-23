using Microsoft.AspNetCore.Mvc;
using WeddingHall.Infrastructure.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtService;

    public AuthController(JwtTokenService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login()
    {
        // TEMP (later replace with DB validation)
        var userId = Guid.NewGuid();
        var email = "admin@hall.com";
        var role = "Admin";

        var token = _jwtService.GenerateToken(userId, email, role);

        return Ok(new
        {
            token
        });
    }
}
