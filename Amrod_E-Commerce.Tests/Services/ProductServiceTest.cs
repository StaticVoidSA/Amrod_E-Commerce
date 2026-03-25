using Amrod_E_Commerce.Data.Context;
using Amrod_E_Commerce.Data.Entities;
using Amrod_E_Commerce.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Amrod_E_Commerce.Tests.Services
{
    public class ProductServiceTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task CreateProduct_Should_Add_Product()
        {
            var db = GetDbContext();
            var service = new ProductService(db);

            var product = new Product
            {
                Name = "Test Product",
                Price = 100,
                Stock = 10,
                Description = "Test description",
                ImageURL = "https://unsplash.com/photos/a-bunch-of-balloons-that-are-shaped-like-email-7NT4EDSI5Ok",
                Id = Guid.NewGuid() 
            };

            var result = await service.CreateProduct(product);

            result.Should().NotBeNull();
            result.Id.Should().NotBe(Guid.Empty); 
            db.Products.Count().Should().Be(1);
        }
    }
}