using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repos
{
    public class HotelRepo : IHotelRepo
    {
        private AppDbContext _context;

        public HotelRepo(AppDbContext Context)
        {
            this._context = Context;
            
        }

        public OperationResult<HotelDTO> Create(HotelDTO Hdto)
        {
            // Business validation First

            if (Hdto == null)
                return OperationResult<HotelDTO>
                    .Falier("Error before saving proccess, hotel information not found to complete insertation proccess");



            // check if exist the same hotel name in same country 
            // check the owner id is exists and this user is actually owner

            var result = _context.Hotels.Add();



        }
    }
}
