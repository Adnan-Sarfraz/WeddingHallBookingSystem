using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.DTOs.SubHall;
using WeddingHall.Application.Interfaces;

namespace WeddingHall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubHallController:ControllerBase
    {
        private readonly ISubHallService _service;
        
        public SubHallController(ISubHallService service)
        {
            _service = service;
        }
        //CREATE
        [HttpPost("CREATE")]
        public async Task<IActionResult> Create(SubHallCreateRequest request)
        {
            var result = await _service.CreateAsync(request);
            if (!result)
                return BadRequest("Invalid HallId OR unable to create sub hall.");

            return Ok("Sub Hall created successfully.");
        }


        //UPDATE
        [HttpPut("UPDATE")]
        public async Task<IActionResult> Update(SubHallUpdateRequest request)
        {
            var result = await _service.UpdateAsync(request);
            if (!result)
                return NotFound("Sub Hall not found.");

            return Ok("Sub Hall updated successfully.");
        }


        //DELETE
        [HttpDelete("Delete/{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var result = await _service.DeleteAsync(guid);
            if (!result)
                return NotFound("Sub Hall not found.");

            return Ok("Sub Hall deleted successfully.");
        }


        //GET_BY_ID
        [HttpGet("GETBYID/{guid}")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

    }
}
