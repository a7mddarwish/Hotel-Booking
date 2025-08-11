using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Helpers
{
    public class OperationResult<T> 
    {

        public bool Success { get; set; }

        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public static OperationResult<T> SuccessOperation(T data)
            => new OperationResult<T> { Success = true, Data = data };

        public static OperationResult<T> Failure(string errors)
            => new OperationResult<T> {Success = false, ErrorMessage = errors };


    }
}
