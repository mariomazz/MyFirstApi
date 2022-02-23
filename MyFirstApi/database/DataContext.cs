using Microsoft.EntityFrameworkCore;
using MyFirstApi.Controllers.models;

namespace MyFirstApi.database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(b => b.Id)
        .HasName("PrimaryKey_UserId");
        }

        public DbSet<User> Users { get; set; }

    }
}
