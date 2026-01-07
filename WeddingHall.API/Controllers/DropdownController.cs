using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.Common;
using WeddingHall.Application.DTOs.DropDown;
using WeddingHall.Application.Interfaces;

namespace WeddingHall.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class DropdownController: ControllerBase
    {
        private readonly IDropdownService _service;
        public DropdownController(IDropdownService service)
        {
            _service = service;
        }

        [HttpGet("cities")]
        public async Task<IActionResult> Cities()
        {
            var data = await _service.GetCitiesAsync();
            return Ok(ApiResponse<List<DropdownResponse>>.SuccessResponse(data, "Cities fetched successfully"));
        }
           // => Ok(await _service.GetCitiesAsync());

        [HttpGet("districts")]
        public async Task<IActionResult> Districts()
        {
            var data = await _service.GetDistrictsAsync();
            return Ok(ApiResponse<List<DropdownResponse>>.SuccessResponse(data, "Districts fetched successfully"));
        }

            //=> Ok(await _service.GetDistrictsAsync());


        [HttpGet("roles")]
        public async Task<IActionResult> Roles()
        {
            var data = await _service.GetRolesAsync();
            return Ok(ApiResponse<List<DropdownResponse>>.SuccessResponse(data, "Roles fetched successfully"));
        }
            //=> Ok(await _service.GetRolesAsync());


        [HttpGet("halls")]
        public async Task<IActionResult> Halls()
        {
            var data = await _service.GetHallsAsync();
            return Ok(ApiResponse<List<DropdownResponse>>.SuccessResponse(data, "Halls fetched successfully"));
        }
            //=> Ok(await _service.GetHallsAsync());


        [HttpGet("users")]
        public async Task<IActionResult> Users()
        {
            var data = await _service.GetUsersAsync();
            return Ok(ApiResponse<List<DropdownResponse>>.SuccessResponse(data, "Users fetched successfully")); 
        }
            //=> Ok(await _service.GetUsersAsync());


        [HttpGet("hall-services")]
        public async Task<IActionResult> HallServices()
        {
            var data = await _service.GetHallServicesAsync();
            return Ok(ApiResponse<List<DropdownResponse>>.SuccessResponse(data, "Hall services fetched successfully"));
           
        }
            //=> Ok(await _service.GetHallServicesAsync());


        [HttpGet("sub-halls")]
        public async Task<IActionResult> SubHalls()
        {
            var data = await _service.GetSubHallsAsync();
            return Ok(ApiResponse<List<DropdownResponse>>.SuccessResponse(data, "Sub-halls fetched successfully"));
        }
            //=> Ok(await _service.GetSubHallsAsync());
    }
}
