using HotelBooking.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.ReposConstracts
{
    public interface IBaseRepo
    {
        public OperationResult<int> SaveChanges();

    }
}
