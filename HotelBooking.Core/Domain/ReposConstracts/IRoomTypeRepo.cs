using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.ReposConstracts
{
    public interface IRoomTypeRepo
    {

        public OperationResult<RoomType> Create(RoomType roomType);
        public Task<OperationResult<IEnumerable<RoomType>>>GetRoomTypes();

    }
}
