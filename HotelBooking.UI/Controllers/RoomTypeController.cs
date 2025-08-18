using HotelBooking.Core.Domain.Services;
using HotelBooking.Core.Domain.ServicesContracts;
using HotelBooking.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeServ _roomTypeServ;
        public RoomTypeController(IRoomTypeServ roomTypeServ)
        {
            _roomTypeServ = roomTypeServ;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var result = await _roomTypeServ.GetAllRoomTypes();

            if (result.Success)
                return Ok(result.Data);

            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage ?? "Failed to retrieve room types.");
        }

        [HttpPost]
        public async Task<IActionResult> AddRoomType([FromBody] AddRoomTypeDTO roomTypeDTO ,  List<IFormFile> images)
        {
            if (roomTypeDTO == null)
                return BadRequest("Room type data is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roomTypeServ.AddNewRoomType(roomTypeDTO , images);
            if (result.Success)
                // return CreatedAtAction(nameof(GetAllRoomTypes), new { id = result.Data?.Id }, result.Data);
                return Ok(new { Data = result.Data });

            return BadRequest(result.ErrorMessage ?? "Failed to add room type.");
        }



    }
}
