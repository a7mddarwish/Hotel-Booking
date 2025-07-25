using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.ReposConstracts
{
    public interface IHotelRepo
    {
        public OperationResult<HotelDTO> Create(HotelDTO dto);
    }
}
