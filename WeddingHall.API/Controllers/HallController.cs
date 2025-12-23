using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        // /api/Hall/CREATE
        [HttpPost]
        //Create user
        public async Task<IActionResult> CreateHall(HallCreateRequest request)
        {
            var result = await _hallService.CreateHallAsync(request);
            if (!result)
            {
                return BadRequest("HALL COULD NOT BE CREATED!");
            }

            return Ok("HALL CREATED SUCCESSFULLY!");

        }
        // /api/Hall/GET ALL 
        [HttpGet]
        //Get All
        public async Task<IActionResult> GetAll()
        {
            var data = await _hallService.GetAllHallsAsync();
            return Ok(data);
        }

        // api/Hall/GET/{id}
        [HttpGet("{id}")]
        //Get by ID
        public async Task<IActionResult> GetHall(Guid id)
        {
            var hall = await _hallService.GetHallByIdAsync(id);
            if (hall == null)
            {
                return NotFound("HALL NOT FOUND");
            }
            return Ok(hall);
        }
        // api/Hall/UPDATE
        [HttpPost("UPDATE")]
        //UPDATE
        public async Task<IActionResult> UpdateHall(HallUpdateRequest request)
        {
            var result = await _hallService.UpdateHallAsync(request);

            if (!result)
            {
                return BadRequest("UPDATE FAILED!");
            }

            return Ok("HALL IS UPDATED SUCCESSFULLY!");


        }
            //api/Hall/DELETE
      [HttpDelete]
       //DELETE DATA
        public async Task<IActionResult> Delete(Guid id)
        {
           var result = await _hallService.DeleteHallAsync(id);
           if (!result)
           {
             return BadRequest("DELETE FAILED!");
           }
             return Ok("HALL DELETED SUCCESSFULLY!");
        }



    }
}
