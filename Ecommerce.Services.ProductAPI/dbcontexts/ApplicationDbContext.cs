using Ecommerce.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.ProductAPI.dbcontexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Variants)
                .WithOne(v => v.Product)
                .HasForeignKey(v => v.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Variant>()
                .HasOne(v => v.Image)
                .WithMany(i => i.Variants)
                .HasForeignKey(v => v.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>().HasData(SeedData.GetProducts());
            modelBuilder.Entity<Image>().HasData(SeedData.GetImages());
            modelBuilder.Entity<Variant>().HasData(SeedData.GetVariants());
        }
    }
}