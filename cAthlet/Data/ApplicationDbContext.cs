using cAthlet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cAthlet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AtemEinstellungen> AtemEinstellungen { get; set; }
        public DbSet<AtemSitzung> AtemSitzung { get; set; }
    }
}
