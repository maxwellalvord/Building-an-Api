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
                  new Park {ParkId = 1, Name = "Crater Lake National Park", Location = "Kalamath Falls, OR", Popularity = 5},
                  new Park {ParkId = 2, Name = "Glacier National Park", Location = "Glacier County, MT", Popularity = 7},
                  new Park {ParkId = 3, Name = "Gateway Arch National Park", Location = "St. Louis, MO", Popularity = 4},
                  new Park {ParkId = 4, Name = "Badlands National Park", Location = "Rapid City, SD", Popularity = 3}
              );
        }
        public DbSet<Park> Parks { get; set; }
    }
}