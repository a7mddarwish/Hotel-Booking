using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.DTOs
{
    public class ShowRoomTypeDTO: BaseRoomTypeDTO
    {      
       public IEnumerable<AmenitieyDTO> amenities { get; set; }
    }
}
