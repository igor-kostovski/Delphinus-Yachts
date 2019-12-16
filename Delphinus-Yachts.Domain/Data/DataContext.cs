using System.Data.Entity;
using Delphinus_Yachts.Domain.Data.Entities;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
