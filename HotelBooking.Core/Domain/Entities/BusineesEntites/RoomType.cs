using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Capacity { get; set; }
        public decimal PricePerNight { get; set; }


        // Navigation
        public List<Room> Rooms { get; set; } = new();
        public List<RoomImage> RoomImages { get; set; } = new();
        public List<Amenitiey> Amenities { get; set; } = new();
    }
}
