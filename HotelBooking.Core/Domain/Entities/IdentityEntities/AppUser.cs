using HotelBooking.Core.Domain.Entities.BusineesEntites;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Core.Domain.Entities.IdentityEntities
{
    public class AppUser : IdentityUser<Guid>
    {

        public string FName { get; set; }
        public string MName { get; set;}
        public string LName { get; set;}

        //get only property , calculated in runtime and Not mapped
        [NotMapped]
        public string FullName { get => $"{FName} {MName} {LName}";}
        public string NationaltyID { get; set; }
        public string? SecondPhoneNum { get; set; }
        public string? JobTitle { get; set; }
        public char Gender { get; set; } // { M , F , N}
        public string? ProfileImage { get; set; }        
        public DateOnly CreatedAt { get; set; }
        public DateOnly BirthDate { get; set; }


        //Navigation

        //AppUser as a Client
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
       
        
        //AppUser as a Hotel Owner
        public List<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
