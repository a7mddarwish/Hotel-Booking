using HotelBooking.Core.Domain.Entities.BusineesEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Core.Domain.Entities.Configuration
{
    public class RoomTypeConfig : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .UseIdentityColumn(1, 1);
        
            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.Description)
                     .IsRequired()
                     .HasMaxLength(500);


            builder.Property(r => r.PricePerNight)
                   .HasColumnType("decimal(18,2)");

            builder.HasMany(r => r.Rooms)
                   .WithOne(r => r.RoomType)
                   .HasForeignKey(r => r.RoomTypeId);

          
            builder.HasMany(r => r.Amenities)
                .WithMany(a => a.RoomTypes)
                .UsingEntity(i => i.ToTable("RoomTypeAmenities"));



        }
    }
}
