using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.Interfaces;

namespace WeddingHall.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DropdownController: ControllerBase
    {
        private readonly IDropdownService _service;
        public DropdownController(IDropdownService service)
        {
            _service = service;
        }

        [HttpGet("cities")]
        public async Task<IActionResult> Cities() => Ok(await _service.GetCitiesAsync());

        [HttpGet("districts")]
        public async Task<IActionResult> Districts() => Ok(await _service.GetDistrictsAsync());


        [HttpGet("roles")]
        public async Task<IActionResult> Roles() => Ok(await _service.GetRolesAsync());


        [HttpGet("halls")]
        public async Task<IActionResult> Halls() => Ok(await _service.GetHallsAsync());


        [HttpGet("users")]
        public async Task<IActionResult> Users() => Ok(await _service.GetUsersAsync());


        [HttpGet("hall-services")]
        public async Task<IActionResult> HallServices()=> Ok(await _service.GetHallServicesAsync());


        [HttpGet("sub-halls")]
        public async Task<IActionResult> SubHalls()=> Ok(await _service.GetSubHallsAsync());
    }
}
