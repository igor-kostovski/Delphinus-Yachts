using System.Data.Entity.ModelConfiguration;
using Delphinus_Yachts.Domain.Data.Entities;

namespace Delphinus_Yachts.Domain.Data.EntityConfigurations
{
    public class BookingConfiguration : EntityTypeConfiguration<Booking>
    {
        public BookingConfiguration()
        {
            Ignore(x => x.Status);
            Property(x => x.StatusAsString).HasColumnName("Status");

            HasOptional(x => x.Contract)
                .WithRequired(x => x.Booking);
        }
    }
}
