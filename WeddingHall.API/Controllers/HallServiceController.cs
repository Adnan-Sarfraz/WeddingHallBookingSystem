using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.Common;
using WeddingHall.Application.DTOs.HallService;
using WeddingHall.Application.Interfaces;
using WeddingHall.Infrastructure.Services;

namespace WeddingHall.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    
    public class HallServiceController : ControllerBase
    {
        private readonly IHallServiceService _hallServiceService;
        public HallServiceController(IHallServiceService hallServiceService)
        {
            _hallServiceService = hallServiceService;
        }
       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HallServiceCreateRequest request)
        {
            var result = await _hallServiceService.CreateAsync(request);
            if (!result)
            {
                return BadRequest(ApiResponse<bool>.FailureResponse("Hall Service could not be created"));

            }
            return Ok(ApiResponse<bool>.SuccessResponse(true, "Hall created successfully"));
        }

        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HallServiceUpdateRequest request)
        {
            var result = await _hallServiceService.UpdateAsync(request);
            if (!result)
            {
                return NotFound(ApiResponse<bool>.FailureResponse("Hall service not found"));
                
            }
            return Ok(ApiResponse<bool>.SuccessResponse(true, "Hall service updated successfully"));
        }

        
        [HttpDelete("{guid}")]
        public async Task<IActionResult>Delete(Guid guid)
        {
            var result = await _hallServiceService.DeleteAsync(guid);

            if (!result)
            {
                return NotFound(ApiResponse<bool>.FailureResponse("Hall service not found"));

            }
            return Ok(ApiResponse<bool>.SuccessResponse(true,"Hall service deleted successfully"));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetById( Guid guid)
        {
            var service =await _hallServiceService.GetByIdAsync(guid);

            if(service==null)
            {
                return NotFound(ApiResponse<bool>.FailureResponse("Hall service not found"));
            }
            return Ok(ApiResponse<object>.SuccessResponse(service, "Hall service fetched successfully"));
        }

        [HttpGet("by-hall/{hallId}")]
        public async Task<IActionResult> GetByHall(Guid hallId)
        {
            var services = await _hallServiceService.GetByHallIdAsync(hallId);

            return Ok(ApiResponse<object>.SuccessResponse(services, "Hall services fetched successfully"));
        }
    }
}
