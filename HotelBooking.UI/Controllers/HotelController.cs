using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.Domain.Services;
using HotelBooking.Core.Domain.ServicesContracts;
using HotelBooking.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelBooking.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelServ _hotelServ;

        public HotelController(IHotelServ hotelServ)
        {
            this._hotelServ = hotelServ;
        }

        [HttpPost("AddNewHotel")]
        public IActionResult CreateHotel([FromBody] HotelDTO hotelDto)
        {

            if (hotelDto == null)
            {
                return BadRequest("Hotel data is null");
            }

            var result = _hotelServ.AddNewHotel(hotelDto);

            if (result.Success)
            {
                return Ok(new { Data = result.Data });
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("GetAllHotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            var result =await _hotelServ.GetAllHotels();       
            
            if (result.Success)
            {
                return Ok(new { Data = result.Data });
            }
            return BadRequest(result.ErrorMessage);
        }


        [HttpPut("UpdateHotel/{id}")]
        public async Task<IActionResult> UpdateHotelAsync(int id, [FromBody] HotelDTO hotelDto)
        {
            if (hotelDto == null)
            {
                return BadRequest("Hotel data is null");
            }
            if (id <= 0 || id != hotelDto.Id)
            {
                return BadRequest("Invalid hotel ID");
            }
            var result = await _hotelServ.UpdateHotel(hotelDto, id);
            if (result.Success)
            {
                return Ok(new { Data = result.Data });
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}
