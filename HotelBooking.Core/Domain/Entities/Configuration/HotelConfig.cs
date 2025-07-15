using HotelBooking.Core.Domain.Entities.BusineesEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Core.Domain.Entities.Configuration
{

    
        public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
        {
            public void Configure(EntityTypeBuilder<Hotel> builder)
            {
                builder.HasKey(h => h.Id);
            builder.Property(h => h.Id)
                       .UseIdentityColumn(1,1);

            builder.Property(h => h.Name)
                       .IsRequired()
                       .HasMaxLength(100);

               builder.Property(h => h.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.City)
                          .IsRequired()
                          .HasMaxLength(100);

               builder.Property(h => h.Localtion)
                       .IsRequired()
                       .HasMaxLength(300);

                builder.Property(h => h.IsActive)
                          .HasDefaultValue(true);

                builder.Property(h => h.PhoneToContact)
                          .IsRequired()
                          .HasMaxLength(20); 

                builder.Property(h => h.Email)
                          .HasMaxLength(100)
                          .IsRequired(false);


            builder.Property(h => h.RateFrom5)
                       .HasColumnType("float");


                builder.HasOne(h => h.Owner)
                       .WithMany(O => O.Hotels)
                       .HasForeignKey(h => h.OwnerId);



            builder.HasMany(H => H.Reservations)
                    .WithOne(r => r.Hotel)
                   .HasForeignKey(H => H.HotelId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
        }

    
}
