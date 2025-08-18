using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.DTOs
{
    public class DisplayImageDTO
    {
        public string ImageUrl { get; set; }       
        public bool IsPrimary { get; set; }
        public Guid ImageId { get; set; } 

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;


    }
}
