using Microsoft.EntityFrameworkCore;
using MyFirstApi.Controllers.models;

namespace MyFirstApi.database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
