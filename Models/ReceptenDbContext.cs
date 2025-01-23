using Microsoft.EntityFrameworkCore;

namespace ReceptenApi.Models
{
    public class ReceptenDbContext : DbContext
    {
        public ReceptenDbContext(DbContextOptions<ReceptenDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recept> Recepten { get; set; }
    }
}
