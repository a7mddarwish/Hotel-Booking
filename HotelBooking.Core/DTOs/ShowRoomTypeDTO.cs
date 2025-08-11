using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.DTOs
{
    public class ShowRoomTypeDTO: BaseRoomTypeDTO
    {      
        IEnumerable<AmenitieyDTO> amenities { get; set; }
    }
}
