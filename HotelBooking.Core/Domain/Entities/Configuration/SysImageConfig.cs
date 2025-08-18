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
    public class SysImageConfig : IEntityTypeConfiguration<SysImage>
    {
        public void Configure(EntityTypeBuilder<SysImage> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(x => x.ImageID);

            builder.Property(x => x.ImageID)
                .HasColumnName("ImageID")
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder.Property(x => x.DisplayURL)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.DeletionURL)
                .IsRequired()
                .HasMaxLength(500);


            builder.Property(x => x.UploadedAt)
                .IsRequired();

          




        }
    }
}
