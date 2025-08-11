using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repos
{
    public class RoomTypeRepo : BaseRepo , IRoomTypeRepo
    {
        private readonly AppDbContext _context;

        public RoomTypeRepo(AppDbContext context) : base(context) 
        {
            this._context = context;
        }
    
        public OperationResult<RoomType> Create(RoomType roomType)
        {
            if (roomType == null)
                return OperationResult<RoomType>.Failure("RoomType cannot be null.");

            if (string.IsNullOrWhiteSpace(roomType.Name))
                return OperationResult<RoomType>.Failure("RoomType name is required.");

            if (roomType.Capacity <= 0)
                return OperationResult<RoomType>.Failure("RoomType capacity must be greater than zero.");

            if (roomType.PricePerNight < 0)
                return OperationResult<RoomType>.Failure("RoomType price must be non-negative.");

           
                _context.RoomTypes.Add(roomType);
                return (_context.SaveChanges() > 0) ?
                    OperationResult<RoomType>.SuccessOperation(roomType) :
                    OperationResult<RoomType>.Failure("An error occurred while creating RoomType");

            
        }

        public async Task<OperationResult<IEnumerable<RoomType>>> GetRoomTypes()
        {
           
                var roomTypes = await _context.RoomTypes
                    .Include(rt => rt.RoomImages)
                    .Include(rt => rt.Amenities)
                    .ToListAsync();

                if(roomTypes is null)
                    return OperationResult<IEnumerable<RoomType>>.Failure($"An error occurred while retrieving room types");
          
           
                return OperationResult<IEnumerable<RoomType>>.SuccessOperation(roomTypes);
        }

       
    }
}
