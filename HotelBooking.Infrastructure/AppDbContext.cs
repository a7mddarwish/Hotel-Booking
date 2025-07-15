using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Domain.Entities.Configuration;
using HotelBooking.Core.Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenitiey> Amenities { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomImage> roomImages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AmenitieyConfig).Assembly);
        }
    }
}
