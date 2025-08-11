using HotelBooking.Core;
using HotelBooking.Core.Domain.Entities.IdentityEntities;
using HotelBooking.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.SC_CoreServices();
            builder.Services.SC_InfraServices(builder.Configuration);

        
            builder.Services.AddIdentity<AppUser, AppRole>()
                               .AddEntityFrameworkStores<AppDbContext>()
                               .AddUserStore<UserStore<AppUser, AppRole, AppDbContext, Guid>>()
                               .AddDefaultTokenProviders();
            // Register the DbContext with the connection string from appsettings.json

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Dev")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
