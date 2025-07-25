using HotelBooking.Core.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core
{
    public static class CoreServices
    {


        public static IServiceCollection SC_CoreServices(this IServiceCollection SP)
        {
            SP.AddAutoMapper(typeof(RegistrationDTO));

            return SP;
        }
    }
}
