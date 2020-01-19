using System.Data.Entity.ModelConfiguration;
using Delphinus_Yachts.Domain.Data.Entities;

namespace Delphinus_Yachts.Domain.Data.EntityConfigurations
{
    public class RouteConfiguration : EntityTypeConfiguration<Route>
    {
        public RouteConfiguration()
        {
            HasMany(x => x.Locations)
                .WithMany(x => x.Routes)
                .Map(x =>
                {
                    x.MapLeftKey("RouteId");
                    x.MapRightKey("LocationId");
                    x.ToTable("RouteLocations");
                });
        }
    }
}
