using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.Common;
using WeddingHall.Application.DTOs.SubHall;
using WeddingHall.Application.Interfaces;

namespace WeddingHall.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SubHallController : ControllerBase
    {
        private readonly ISubHallService _service;

        public SubHallController(ISubHallService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubHallCreateRequest request)
        {
            var result = await _service.CreateAsync(request);

            if (!result)
            {
                return BadRequest(ApiResponse<bool>.FailureResponse("Invalid hall or unable to create sub-hall"));
            }

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Sub-hall created successfully"));
        }

        [HttpPut]
        public async Task<IActionResult> Update(SubHallUpdateRequest request)
        {
            var result = await _service.UpdateAsync(request);

            if (!result)
            {
                return NotFound(ApiResponse<bool>.FailureResponse("Sub-hall not found"));
            }

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Sub-hall updated successfully"));
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var result = await _service.DeleteAsync(guid);

            if (!result)
            {
                return NotFound(ApiResponse<bool>.FailureResponse("Sub-hall not found"));
            }

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Sub-hall deleted successfully"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();

            return Ok(ApiResponse<object>.SuccessResponse(list, "Sub-halls fetched successfully"));
        }
    }
}