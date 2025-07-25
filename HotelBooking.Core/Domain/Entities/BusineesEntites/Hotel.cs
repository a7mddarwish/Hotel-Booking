using HotelBooking.Core.Domain.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Localtion { get; set; }
        public float RateFrom5 { get; set; }
        public Guid OwnerId { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string PhoneToContact { get; set; }

        //Navigation
        public AppUser Owner {  get; set; }
        public List<Room> Rooms { get; set; }
        public List<Reservation> Reservations { get; set; }


    }
}
