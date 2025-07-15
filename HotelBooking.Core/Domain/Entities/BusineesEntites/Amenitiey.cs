using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class Amenitiey
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string IconUrl { get; set; }  

        public List<RoomType> RoomTypes { get; set; } = new List<RoomType>();
    }
}
