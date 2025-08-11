using HotelBooking.Core.Domain.Entities.BusineesEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.Configuration
{
    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {

            builder.Property(p => p.RoomId).UseIdentityColumn(1,1);
            builder.HasKey(x => new {x.RoomId , x.HotelId});

            builder.HasOne(p => p.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(p => p.HotelId)
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
