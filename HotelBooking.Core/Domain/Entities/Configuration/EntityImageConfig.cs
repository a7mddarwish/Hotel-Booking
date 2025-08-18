using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Core.Domain.Entities.Configuration
{
    public class EntityImageConfig : IEntityTypeConfiguration<EntityImage>
    {
        public void Configure(EntityTypeBuilder<EntityImage> builder)
        {

            builder.ToTable("EntityImages");

            builder.HasKey(ei => ei.Id);
            builder.Property(ei => ei.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(ei => ei.EntitySet)
                .IsRequired()
                .HasMaxLength(35)
                .HasColumnType("VARCHAR")
                .HasConversion(
                c => c.ToString().Trim().ToUpper(),
                c => (enImageEntites)Enum.Parse(typeof(enImageEntites), c)
                );


                
            builder.Property(ei => ei.EntityID)
                .IsRequired()
                .HasColumnType("VARCHAR(36)")
                .HasConversion(
                    c => c.ToString(),
                    c => c
                );
            builder.Property(x => x.IsPrimary)
              .IsRequired()
              .HasDefaultValue(false);



            builder.Property(ei => ei.ImageID)
                .IsRequired();

            builder.HasOne(ei => ei.Image)
                .WithMany(I => I.EntityImages)
                .HasForeignKey(ei => ei.ImageID)
                .OnDelete(DeleteBehavior.Cascade);



        }

    }
}
