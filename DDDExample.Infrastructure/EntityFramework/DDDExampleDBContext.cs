using DDDExample.domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DDDExample.Infrastructure.EntityFramework
{
    public class DDDExampleDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=84.54.12.100;Port=5432;Database=h2dAlisverisDb;Username=postgres;Password=h2d");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
