using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Helpers
{

    public class GenericToStringConverter<T> : ValueConverter<T, string>
    {
        public GenericToStringConverter() : base(
           v => v == null ? null : v.ToString(),
           v => ConvertFromString(v)
       )
        {
        }

        private static T ConvertFromString(string value)
        {
            if (value == null)
                return default;

            var targetType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

            return (T)Convert.ChangeType(value, targetType);
        }
    }

}
