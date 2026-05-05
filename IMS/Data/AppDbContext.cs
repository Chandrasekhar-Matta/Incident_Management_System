
using Microsoft.EntityFrameworkCore;

using IMS.Models;

namespace IMS.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<RCA> RCAs { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
