using System.Data.Entity;
using Delphinus_Yachts.Domain.Data.Entities;
using Delphinus_Yachts.Domain.Data.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Delphinus_Yachts.Domain.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext() : base("DataContext")
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookingConfiguration());
            modelBuilder.Configurations.Add(new ContractConfiguration());
            modelBuilder.Configurations.Add(new RouteConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
