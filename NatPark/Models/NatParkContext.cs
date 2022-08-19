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
                  new Park { ParkId = 1, Name = "Crater Lake", Popularity = 5}
              );
        }
        public DbSet<Park> Parks { get; set; }
    }
}