using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Helpers
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<T> UseStringConversion<T>(this PropertyBuilder<T> builder)
        {
            return builder.HasConversion(new GenericToStringConverter<T>());
        }
    }

}
