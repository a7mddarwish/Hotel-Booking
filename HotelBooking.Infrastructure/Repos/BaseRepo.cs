using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.Helpers;

namespace HotelBooking.Infrastructure.Repos
{
    public abstract class BaseRepo : IBaseRepo
    {
        private readonly AppDbContext _context;

        public BaseRepo(AppDbContext context) 
        {
            this._context = context;
        }

        public OperationResult<int> SaveChanges()
        {
            int rowsaffected = (int)_context.SaveChanges();
            return (rowsaffected > 0) ? OperationResult<int>.SuccessOperation(rowsaffected) :
                OperationResult<int>.Failure("Saving proccess faild");

        }
    }
}
