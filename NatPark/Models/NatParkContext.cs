using Microsoft.EntityFrameworkCore;

namespace NatPark.Models
{
    public class NatParkContext : DbContext
    {
        public SkateRateContext(DbContextOptions<NatParkContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Park>()
              .HasData(
                // seed data here
              );
        }
        public DbSet<Park> Parks { get; set; }
    }
}