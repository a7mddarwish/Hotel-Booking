using HotelBooking.Core.Domain.Entities.BusineesEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Core.Domain.Entities.Configuration
{
    public class RoomImageConfig : IEntityTypeConfiguration<RoomImage>
    {
        public void Configure(EntityTypeBuilder<RoomImage> builder)
        {
            builder.HasKey(r => new { r.ImageURL}); 

            builder.Property(r => r.ImageURL).IsRequired();

            builder.HasOne(r => r.roomtype)
                   .WithMany(rt => rt.RoomImages)
                   .HasForeignKey(r => r.RoomTypeID);
        }
    }
}
