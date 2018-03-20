using Microsoft.EntityFrameworkCore;
using WineFridge.Models;

namespace WineFridge.Data
{
    public class WineDbContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Winery> Wineries { get; set; }
        public DbSet<WineType> WineTypes { get; set; }
        public DbSet<RackLocation> RackLocations { get; set; }

        public WineDbContext(DbContextOptions<WineDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RackLocation>()
                .HasKey(l => new { l.WineID, l.RackID });
        }
    }
}
