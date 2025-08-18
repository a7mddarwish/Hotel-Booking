using HotelBooking.Core.Domain.Entities.IdentityEntities;
using HotelBooking.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class EntityImage
    {

        public Guid Id { get; set; }
        public enImageEntites EntitySet { get; set; }
        public object EntityID { get; set; } // Change from object to Guid or int as needed                                          
        public Guid ImageID { get; set; }
        public bool IsPrimary { get; set; } = false;


        //Navigation  

        public SysImage Image { get; set; }
        

    }
}
