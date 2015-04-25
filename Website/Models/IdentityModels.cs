using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Website.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("IdentityString")
        {
        }

        public System.Data.Entity.DbSet<Website.Models.Area> Areas { get; set; }

        public System.Data.Entity.DbSet<Website.Models.HallType> HallTypes { get; set; }

        public System.Data.Entity.DbSet<Website.Models.Booking> Bookings { get; set; }

        public System.Data.Entity.DbSet<Website.Models.Hall> Halls { get; set; }

        public System.Data.Entity.DbSet<Website.Models.Venue> Venues { get; set; }

        public System.Data.Entity.DbSet<Website.Models.HallTypeRelation> HallTypeRelations { get; set; }
    }
}