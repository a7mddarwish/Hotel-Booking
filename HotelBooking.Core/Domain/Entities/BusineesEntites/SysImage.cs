using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class SysImage
    {
        public Guid ImageID { get; set; } 
        public string DisplayURL { get; set; }

        public string DeletionURL { get; set; }

        public DateTime UploadedAt { get; set; } =  DateTime.UtcNow;



        //Navigation
       
        public List<EntityImage> EntityImages { get; set; } = new();


    }
}
