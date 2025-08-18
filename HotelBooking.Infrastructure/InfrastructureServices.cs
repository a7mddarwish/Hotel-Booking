using HotelBooking.Core.Domain.Entities.IdentityEntities;
using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.ExternalServContracts;
using HotelBooking.Infrastructure.ExternalServ;
using HotelBooking.Infrastructure.Repos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure
{
    public static class InfrastructureServices
    {

        public static IServiceCollection SC_InfraServices(this IServiceCollection Services , IConfiguration config)
        {
            InjectRepos(Services);
           
            return Services;
        }

        private static void InjectRepos(IServiceCollection Services)
        {
            Services.AddScoped<IHotelRepo, HotelRepo>();
            Services.AddScoped<IAmenitieyRepo, AmenitieyRepo>();
            Services.AddScoped<IRoomTypeRepo, RoomTypeRepo>();
            Services.AddScoped<ICloudServ, CloudServ>();

        }

    }
}
