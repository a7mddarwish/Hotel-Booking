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
    internal class AmenitieyRepo : BaseRepo , IAmenitieyRepo
    {
        private readonly AppDbContext _context;

        public AmenitieyRepo(AppDbContext context) : base(context) 
        {
            this._context = context;
        }


        public OperationResult<Amenitiey> AddAmenitiey(Amenitiey amenitiey)
        {
            if (amenitiey == null)
                return OperationResult<Amenitiey>.Failure("Sothing went wrong while insertion Process");

            _context.Amenities.Add(amenitiey);

            if(_context.SaveChanges() > 0)
            return OperationResult<Amenitiey>.SuccessOperation(amenitiey);


            return OperationResult<Amenitiey>.Failure("Sothing went wrong while Saving Process");



        }

        public async Task<OperationResult<IEnumerable<Amenitiey>>> GetAmenities()
        {

            var amineties = await _context.Amenities.ToListAsync();

            if (!amineties.Any())
            return OperationResult<IEnumerable<Amenitiey>>.Failure("Sothing went wrong while fetching data");


            if (amineties == null)
            return OperationResult<IEnumerable<Amenitiey>>.Failure("can not found any amenities");


            return OperationResult<IEnumerable<Amenitiey>>.SuccessOperation(amineties);


        }

        public OperationResult<int> SaveChanges()
        {
            int rowsaffected =(int) _context.SaveChanges();
            return (rowsaffected > 0) ? OperationResult<int>.SuccessOperation(rowsaffected) :
                OperationResult<int>.Failure("Saving proccess faild");

        }
    }
}
