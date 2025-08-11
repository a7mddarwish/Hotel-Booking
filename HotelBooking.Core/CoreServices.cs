using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.Domain.Services;
using HotelBooking.Core.Domain.ServicesContracts;
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


        public static IServiceCollection SC_CoreServices(this IServiceCollection SC)
        {
            SC.AddAutoMapper(typeof(RegistrationDTO));
            SC_RegisterServices(SC);

            return SC;
        }

        public static void SC_RegisterServices(IServiceCollection SC)
        {
            SC.AddScoped<IHotelServ, HotelServ>();
            SC.AddScoped<IAmenitiyServ, AmenitiyServ>();
        }


    }
}
