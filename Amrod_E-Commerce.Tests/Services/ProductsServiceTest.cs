using Amrod_E_Commerce.Data.Context;
using Amrod_E_Commerce.Data.Entities;
using Amrod_E_Commerce.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Amrod_E_Commerce.Tests.Services
{
    public class ProductServiceTests
    {
        private AppDbContext GetInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        #region CreateProduct Tests

        [Fact]
        public async Task CreateProduct_Should_Add_Product_Successfully()
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Laptop",
                Price = 999.99m,
                Stock = 50,
                Description = "High performance laptop"
            };

            var result = await service.CreateProduct(product);

            Assert.NotNull(result);
            Assert.Equal("Test Laptop", result.Name);
            Assert.Equal(999.99m, result.Price);
            Assert.Equal(1, await db.Products.CountAsync());
        }

        #endregion

        #region UpdateProduct Tests

        [Fact]
        public async Task UpdateProduct_Should_Update_Existing_Product_Successfully()
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            var original = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Old Name",
                Price = 100,
                Stock = 10,
                Description = "Old description"
            };
            await service.CreateProduct(original);

            var updatedData = new Product
            {
                Name = "New Updated Name",
                Price = 150.50m,
                Stock = 25,
                Description = "New description",
                ImageURL = "https://example.com/image.jpg"
            };

            var result = await service.UpdateProduct(original.Id, updatedData);

            Assert.Equal("New Updated Name", result.Name);
            Assert.Equal(150.50m, result.Price);
            Assert.Equal(25, result.Stock);
            Assert.Equal("New description", result.Description);
            Assert.Equal("https://example.com/image.jpg", result.ImageURL);
        }

        [Fact]
        public async Task UpdateProduct_Should_Throw_When_Product_Not_Found()
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            var updatedData = new Product { Name = "New Name", Price = 200 };

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(
                () => service.UpdateProduct(Guid.NewGuid(), updatedData));

            Assert.Equal("Product not found.", exception.Message);
        }

        [Fact]
        public async Task UpdateProduct_Should_Throw_When_Name_Is_Empty()
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            var product = new Product { Id = Guid.NewGuid(), Name = "Original", Price = 100 };
            await service.CreateProduct(product);

            var updatedData = new Product { Name = "", Price = 150 };

            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => service.UpdateProduct(product.Id, updatedData));

            Assert.Equal("Product Name is required.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public async Task UpdateProduct_Should_Throw_When_Price_Is_ZeroOrNegative(decimal price)
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            var product = new Product { Id = Guid.NewGuid(), Name = "Original", Price = 100 };
            await service.CreateProduct(product);

            var updatedData = new Product { Name = "New Name", Price = price };

            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => service.UpdateProduct(product.Id, updatedData));

            Assert.Equal("Product Price must be greater than zero.", exception.Message);
        }

        #endregion

        #region GetProductsPaged Tests

        [Fact]
        public async Task GetProductsPaged_Should_Return_Correct_Page_And_TotalCount()
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            for (int i = 1; i <= 50; i++)
            {
                await service.CreateProduct(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = $"Product {i:D2}",
                    Price = i * 10m,
                    Stock = i * 2
                });
            }

            var result = await service.GetProductsPaged(pageNumber: 2, pageSize: 10);

            Assert.Equal(10, result.Items.Count());
            Assert.Equal(2, result.PageNumber);
            Assert.Equal(10, result.PageSize);
            Assert.Equal(50, result.TotalCount);
            Assert.Equal("Product 11", result.Items.First().Name);  
            Assert.Equal("Product 20", result.Items.Last().Name);
        }

        [Fact]
        public async Task GetProductsPaged_Should_Apply_SearchTerm_Correctly()
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            await service.CreateProduct(new Product { Name = "Gaming Laptop", Price = 1200 });
            await service.CreateProduct(new Product { Name = "Office Chair", Price = 150 });
            await service.CreateProduct(new Product { Name = "Wireless Mouse", Price = 45 });

            var result = await service.GetProductsPaged(pageNumber: 1, pageSize: 10, searchTerm: "laptop");

            Assert.Single(result.Items);
            Assert.Equal("Gaming Laptop", result.Items.First().Name);
            Assert.Equal(1, result.TotalCount);
        }

        [Theory]
        [InlineData("name", true, "Product 01")]   
        [InlineData("name", false, "Product 50")] 
        [InlineData("price", true, "Product 01")]
        [InlineData("price", false, "Product 50")]
        [InlineData("stock", true, "Product 01")]
        public async Task GetProductsPaged_Should_Order_Correctly(string orderBy, bool ascending, string expectedFirstName)
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            for (int i = 1; i <= 50; i++)
            {
                await service.CreateProduct(new Product
                {
                    Name = $"Product {i:D2}",
                    Price = i * 10m,
                    Stock = i * 5
                });
            }

            var result = await service.GetProductsPaged(
                pageNumber: 1, 
                pageSize: 10, 
                orderBy: orderBy, 
                ascending: ascending);

            Assert.Equal(expectedFirstName, result.Items.First().Name);
        }

        [Fact]
        public async Task GetProductsPaged_Should_Return_Empty_List_When_No_Products()
        {
            var db = GetInMemoryDb();
            var service = new ProductService(db);

            var result = await service.GetProductsPaged(pageNumber: 1, pageSize: 10);

            Assert.Empty(result.Items);
            Assert.Equal(0, result.TotalCount);
            Assert.Equal(1, result.PageNumber);
            Assert.Equal(10, result.PageSize);
        }

        #endregion
    }
}