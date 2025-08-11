using HotelBooking.Core.Domain.Entities.BusineesEntites;
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
        public OperationResult<Hotel> AddNewHotel(Hotel HOTEL);
        public Task<OperationResult<Hotel>> Update(Hotel hotel);
        public Task<OperationResult<Hotel>> Find(int id);
        public Task<OperationResult<List<Hotel>>> GetAllInCity(string City);
        public Task<OperationResult<List<Hotel>>> GetAllInCountry(string Country);
        public Task<OperationResult<List<Hotel>>> GetAllHotelsByOwnerId(Guid OwnerId);
        public Task<OperationResult<List<Hotel>>> GetAllHotels();
        public Task<OperationResult<List<Hotel>>> GetAllHotelsbystatus(bool IsActive);



    }
}
