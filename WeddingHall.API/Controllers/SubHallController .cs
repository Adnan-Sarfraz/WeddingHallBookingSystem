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
                return BadRequest(" INVALID HALL OR UNABLE TO CREATE SUB-HALL. ");

            return Ok(" SUB-HALL CREATED SUCCESSFULLY! ");
        }


        //UPDATE
        [HttpPut("UPDATE")]
        public async Task<IActionResult> Update(SubHallUpdateRequest request)
        {
            var result = await _service.UpdateAsync(request);
            if (!result)
                return NotFound(" SUB-HALL NOT FOUND. ");

            return Ok(" SUB-HALL UPDATED SUCCESFULLY. ");
        }


        //DELETE
        [HttpDelete("Delete/{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var result = await _service.DeleteAsync(guid);
            if (!result)
                return NotFound(" SUB-HALL NOT FOUND. ");

            return Ok(" SUB-HALL DELETED SUCCESSFULLY. ");
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
