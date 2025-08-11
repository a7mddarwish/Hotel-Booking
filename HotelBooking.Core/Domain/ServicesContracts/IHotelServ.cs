using Azure;
using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.ServicesContracts
{
    public interface IHotelServ
    {
        public OperationResult<HotelDTO> AddNewHotel(HotelDTO hotelDto);
        public Task<OperationResult<HotelDTO>> UpdateHotel(HotelDTO hotelDto , int id);

        /// <summary>
        /// Find Hotel by Hotel id -Overload-
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OperationResult<HotelDTO></returns>
        public Task<OperationResult<HotelDTO>> Find(int id);
        public Task<OperationResult<List<HotelDTO>>> GetAllHotels();


    }
}
