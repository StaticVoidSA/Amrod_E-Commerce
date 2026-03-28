using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Amrod_E_Commerce.Data.Entities;

namespace Amrod_E_Commerce.Data.Context
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var products = new List<Product>();

            var imageUrls = new[]
            {
                "https://images.unsplash.com/photo-1581291518837-7f0f8d73d8a4?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1580910051070-1d1d17a112ed?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1581291519195-ef11498d1cf7?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1512499617640-c2f999b0ed0d?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1503602642458-232111445657?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1491553895911-0055eca6402d?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1539883379635-9f820d8917f5?auto=format&fit=crop&w=200&q=80",
                "https://images.unsplash.com/photo-1526170375885-4d8ecf77b99f?auto=format&fit=crop&w=200&q=80"
            };

            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = $"Product {i}",
                    Description = $"Description for Product {i}",
                    ImageURL = imageUrls[i % imageUrls.Length], 
                    Price = Math.Round((decimal)(random.NextDouble() * 1000 + 10), 2),
                    Stock = random.Next(0, 100)
                });
            }

            modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}