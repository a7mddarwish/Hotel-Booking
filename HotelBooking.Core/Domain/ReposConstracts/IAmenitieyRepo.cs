using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Helpers;

namespace HotelBooking.Core.Domain.ReposConstracts
{
    public interface IAmenitieyRepo
    {
        public Task<OperationResult<IEnumerable<Amenitiey>>> GetAmenities();

        public OperationResult<Amenitiey> AddAmenitiey(Amenitiey amenitiey );

    }
}
