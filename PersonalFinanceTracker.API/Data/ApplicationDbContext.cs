using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.API.Models;

namespace PersonalFinanceTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}