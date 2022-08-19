using Microsoft.EntityFrameworkCore;

namespace NatPark.Models
{
    public class NatParkContext : DbContext
    {
        public NatParkContext(DbContextOptions<NatParkContext> options)
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