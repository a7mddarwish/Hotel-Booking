using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class RoomImage
    {
        public string ImageURL { get; set; }
        public int RoomTypeID { get; set; }

        public RoomType roomtype { get; set; }
    }
}
