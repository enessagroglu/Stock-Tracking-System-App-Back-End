using Microsoft.EntityFrameworkCore;
using StockTrackingSystemApp_BackEnd.Domain.Entities;

namespace StockTrackingSystemApp_BackEnd.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet tanımlamaları
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Depot> Depots { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ürün ve kategori ilişkisi: Bir kategori birden fazla ürüne sahip olabilir.
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Ürün ve depo ilişkisi: Bir depo birden fazla ürüne sahip olabilir.
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Depot)
                .WithMany(d => d.Products)
                .HasForeignKey(p => p.DepotId);

            // Depo ve kullanıcı ilişkisi: Bir kullanıcı birden fazla depoya sahip olabilir.
            modelBuilder.Entity<Depot>()
                .HasOne(d => d.User)
                .WithMany(u => u.Depots)
                .HasForeignKey(d => d.UserId);
        }
    }
}
