using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace HotelBooking.Core.Domain.ServicesContracts
{
    public interface IRoomTypeServ
    {
        public Task<OperationResult<IEnumerable<ShowRoomTypeDTO>>> GetAllRoomTypes();

        public Task<OperationResult<ShowRoomTypeDTO>> AddNewRoomType(AddRoomTypeDTO roomTypeDTO , List<IFormFile> images);
    }
}
