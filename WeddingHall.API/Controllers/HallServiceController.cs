using Microsoft.AspNetCore.Mvc;
using WeddingHall.Application.DTOs.HallService;
using WeddingHall.Application.Interfaces;
using WeddingHall.Infrastructure.Services;

namespace WeddingHall.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallServiceController : ControllerBase
    {
        private readonly IHallServiceService _hallServiceService;
        public HallServiceController(IHallServiceService hallServiceService)
        {
            _hallServiceService = hallServiceService;
        }
        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HallServiceCreateRequest request)
        {
            var result = await _hallServiceService.CreateAsync(request);
            if (!result)
            {
                return BadRequest("SERVICE COULD NOT CREATED!");

            }
            return Ok("HALL SERVICE CREATED SUCCESSFULLY!");
        }

        //UPDATE
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HallServiceUpdateRequest request)
        {
            var result = await _hallServiceService.UpdateAsync(request);
            if (!result)
            {
                return NotFound("HALL SERVICE NOT FOUND!");
                
            }
            return Ok("HALL SERVICE UPDATED SUCCESSFULLY!");
        }

        //DELETE
        [HttpDelete("{guid}")]
        public async Task<IActionResult>Delete(Guid guid)
        {
            var result = await _hallServiceService.DeleteAsync(guid);

            if (!result)
            {
                return NotFound("HALL SERVICE COULD NOT FOUND!");

            }
            return Ok("SERVICE DELETED SUCCESSFULLY!");
        }


        //GET BY ID 
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetById( Guid guid)
        {
            var service =await _hallServiceService.GetByIdAsync(guid);

            if(service==null)
            {
                return NotFound("HALL SERVICE NOT FOUND!");
            }
            return Ok(service);
        }


        //  GET BY HALL ID 
        [HttpGet("by-hall/{hallId}")]
        public async Task<IActionResult> GetByHall(Guid hallId)
        {
            var services = await _hallServiceService.GetByHallIdAsync(hallId);
            return Ok(services);
        }
    }
}
