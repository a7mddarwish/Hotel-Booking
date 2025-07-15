using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomPhNumber { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public byte Floor { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Status { get; set; } = "Available";

        //Navigations
        public Hotel Hotel { get; set; }
        public RoomType RoomType { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
