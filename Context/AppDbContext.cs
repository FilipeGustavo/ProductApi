using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Controllers.Models;

namespace VShop.ProductApi.Context
{
public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //category
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>().Property(c => c.Name)
                                           .HasMaxLength(100)
                                           .IsRequired();

            //product
            modelBuilder.Entity<Product>().Property(p => p.Name)
                                          .HasMaxLength(100)
                                          .IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Description)
                                          .HasMaxLength(100)
                                          .IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.ImageURL)
                                          .HasMaxLength(100)
                                          .IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.price)
                                          .HasPrecision(12, 2);

            modelBuilder.Entity<Category>().HasMany(p => p.Products)
                                            .WithOne(c => c.caterory)
                                            .IsRequired()
                                            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Acessórios"
                }
                );

        }
    }
}


