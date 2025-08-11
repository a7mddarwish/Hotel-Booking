using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.ServicesContracts
{
    public interface IAmenitiyServ
    {
        public Task<OperationResult<IEnumerable<AmenitieyDTO>>> GetAmenities();
        public OperationResult<AmenitieyDTO> AddNewAminity(AmenitieyDTO amenitieyDTO);
    }
}
