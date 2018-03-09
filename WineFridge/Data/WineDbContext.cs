using Microsoft.EntityFrameworkCore;
using WineFridge.Models;

namespace WineFridge.Data
{
    public class WineDbContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }

        public WineDbContext(DbContextOptions<WineDbContext> options)
            : base(options)
        { }
    }
}
