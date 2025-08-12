using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.ServicesContracts
{
    public interface IRoomTypeServ
    {
        public Task<OperationResult<IEnumerable<ShowRoomTypeDTO>>> GetAllRoomTypes();

        public OperationResult<ShowRoomTypeDTO> AddNewRoomType(AddRoomTypeDTO roomTypeDTO);
    }
}
