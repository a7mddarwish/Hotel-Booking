using HotelBooking.Core.Domain.Entities.BusineesEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Core.Domain.Entities.Configuration
{
    public class AmenitieyConfig : IEntityTypeConfiguration<Amenitiey>
    {
        public void Configure(EntityTypeBuilder<Amenitiey> builder)
        {
            builder.HasKey(a => a.Id);
             builder.Property(a => a.Id)
                .UseIdentityColumn(1,1);       

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);


        
        
        
        
        }
    }

}
