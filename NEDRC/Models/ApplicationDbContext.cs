using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace NEDRC.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Reports> Reports { get; set; }

        public DbSet<DemoModel> DemoModels { get; set; }
        //public System.Data.Entity.DbSet<NEDRC.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}