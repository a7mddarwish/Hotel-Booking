using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.DTOs
{
    public class AddAminityDTO
    { 
        public string Name { get; set; }
        public IFormFile Aminityimg { get; set; }

    }
}
