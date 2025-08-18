using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.DTOs
{
    public class FullImgInfoDTO
    { 
        public string DisplayUrl {  get; set; }
        public string DeleteUrl {  get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;


    }
}
