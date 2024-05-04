using Microsoft.EntityFrameworkCore;

namespace store_admin_cs_ws.Models
{
    public class SaleManagementSystemContext : DbContext
    {
        public SaleManagementSystemContext(DbContextOptions<SaleManagementSystemContext> options) : base(options)
        {
        }
        public DbSet<ProductOnSale> ProductOnSales { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");

            optionsBuilder.UseNpgsql($"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUsername};Password={dbPassword}");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships configuration
            modelBuilder.Entity<ProductOnSale>()
                .HasOne(p => p.Product)
                .WithMany()
                .IsRequired(false);

            modelBuilder.Entity<ProductOnSale>()
                .HasOne(p => p.Catalog)
                .WithMany()
                .IsRequired(false);
        }
    }
}
