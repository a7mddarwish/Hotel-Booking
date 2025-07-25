using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Domain.Enums;
using HotelBooking.Core.Domain.Entities.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.Configuration
{

    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {


        public void Configure(EntityTypeBuilder<Reservation> builder)
        {

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .HasDefaultValueSql("newid()");

            builder.Property(r => r.TotalPrice)
                   .HasColumnType("decimal(18,2)");

            builder.Property(r => r.Status)
                   .HasConversion<int>();

            builder.Property(r => r.PaymentStatus)
                   .HasConversion<int>();

            builder.HasOne(r => r.Room)
                   .WithMany(r => r.Reservations)
                   .HasForeignKey(r => new { r.RoomId, r.HotelId });


            builder.HasOne(r => r.User)
                   .WithMany(u => u.Reservations)
                   .HasForeignKey(r => r.UserId);

        }

    }

}
