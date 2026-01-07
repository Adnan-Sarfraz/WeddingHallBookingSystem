using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.Common;
using WeddingHall.Application.DTOs.Hall;
using WeddingHall.Application.Interfaces;


namespace WeddingHall.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IHallService _hallService;
        public HallController(IHallService hallService)
        {
            _hallService = hallService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateHall(HallCreateRequest request)
        {
            var result = await _hallService.CreateHallAsync(request);
            if (!result)
            {
                return BadRequest(ApiResponse<bool>.FailureResponse("Hall could not be created"));
                //return BadRequest("HALL COULD NOT BE CREATED!");
            }

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Hall created successfully"));

            //return Ok("HALL CREATED SUCCESSFULLY!");

        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _hallService.GetAllHallsAsync();

            return Ok(ApiResponse<object>.SuccessResponse(data, "Halls fetched successfully"));
            //return Ok(data);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHall(Guid id)
        {
            var hall = await _hallService.GetHallByIdAsync(id);
            if (hall == null)
            {
                return NotFound(ApiResponse<object>.FailureResponse("Hall not found"));
                //return NotFound("HALL NOT FOUND");
            }
            return Ok(ApiResponse<object>.SuccessResponse(hall, "Hall fetched successfully"));
            //return Ok(hall);
        }

        [HttpPost("UPDATE")]
        public async Task<IActionResult> UpdateHall(HallUpdateRequest request)
        {
            var result = await _hallService.UpdateHallAsync(request);

            if (!result)
            {
                return BadRequest(ApiResponse<bool>.FailureResponse("Hall update failed"));
                //return BadRequest("UPDATE FAILED!");
            }

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Hall updated successfully"));
            //return Ok("HALL IS UPDATED SUCCESSFULLY!");


        }
            
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
           var result = await _hallService.DeleteHallAsync(id);
           if (!result)
           {
             return BadRequest(ApiResponse<bool>.FailureResponse("Hall Delete Failed"));
           }
             return Ok(ApiResponse<bool>.SuccessResponse(true, "Hall Deleted Successfully"));
        }



    }
}
