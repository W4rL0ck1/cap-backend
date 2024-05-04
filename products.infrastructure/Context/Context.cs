using Microsoft.EntityFrameworkCore;
using products.core;
using products.core.Entities;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Checkout> Checkout { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> User { get; set; }

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Port=5432;Username=myuser;Password=mypassword;Database=mydatabase;Pooling=true;",
                    options => options.MigrationsAssembly("products.infrastructure"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here if needed
        }
    }
}
