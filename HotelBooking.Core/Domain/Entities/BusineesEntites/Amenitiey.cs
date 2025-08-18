using HotelBooking.Core.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class Amenitiey
    { 
        public int Id { get; set; }
        public string Name { get; set; }   
        

        [NotMapped]
        public EntityImage EntityImageInfo { get; set; } 

        // Navigation
        public List<RoomType> RoomTypes { get; set; } = new List<RoomType>();
    }

    
}
