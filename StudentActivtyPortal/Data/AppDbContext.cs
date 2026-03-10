using Microsoft.EntityFrameworkCore;
using StudentActivityPortal.Models;

namespace StudentActivityPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}