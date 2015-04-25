using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Website.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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