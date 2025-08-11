using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.DTOs
{
    public abstract class BaseRoomTypeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public List<string> RoomImages { get; set; } = new();
    }
}
