using Microsoft.AspNetCore.Mvc;
using HotelBooking.Core.Domain.ServicesContracts;
using HotelBooking.Core.DTOs;

namespace HotelBooking.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenitiyServ serv;

        public AmenitiesController(IAmenitiyServ serv)
        {
            this.serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAmenities()
        {
            
            var result = await serv.GetAmenities();

            if (result.Success)            
                return Ok(result.Data);
            

            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage ?? "An error occurred while retrieving amenities.");
        }

        [HttpPost("kajd")]
        public IActionResult AddNewAmenity([FromBody] AmenitieyDTO amenitieyDTO)
        {
            if (amenitieyDTO == null)
                return BadRequest("Amenity data is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = serv.AddNewAminity(amenitieyDTO);

            if (result.Success)
                return CreatedAtAction(nameof(GetAllAmenities), new { id = result.Data?.Id }, result.Data);
            
          
            return BadRequest(result.ErrorMessage ?? "Failed to add amenity.");
        }

      
    }
}
