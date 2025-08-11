using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelBooking.Core.DTOs
{
    public class AddRoomTypeDTO : BaseRoomTypeDTO
    {
        IEnumerable<int> amenitiesIDs { get; set; }


    }
}
