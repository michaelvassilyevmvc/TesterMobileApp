using Microsoft.EntityFrameworkCore;
using Tester.WebApi.Service.Models;

namespace Tester.WebApi.Service.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<RecoveryEvent> RecoveryEvents { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Tester.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Phone>().ToTable("Phones");
            modelBuilder.Entity<RecoveryEvent>().ToTable("RecoveryEvents");
        }

    }
}
