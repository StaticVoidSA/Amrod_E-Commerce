using Amrod_E_Commerce.Data.Context;
using Amrod_E_Commerce.Data.Entities;
using Amrod_E_Commerce.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Amrod_E_Commerce.Tests.Services
{
    public class CartServiceTests
    {
        private AppDbContext GetInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        #region AddItem Tests

        [Fact]
        public async Task AddItem_Should_Create_New_Cart_And_Add_Item_When_Cart_Does_Not_Exist()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);

            var user = new User { Id = Guid.NewGuid(), Email = "test@example.com" };
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Price = 299.99m
            };

            var addedItem = await service.AddItem(user, product, 2);

            Assert.NotNull(addedItem);
            Assert.Equal(product.Id, addedItem.ProductId);
            Assert.Equal(2, addedItem.Quantity);
            Assert.Equal(299.99m, addedItem.Price);

            var cart = await db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == user.Id);

            Assert.NotNull(cart);
            Assert.Single(cart.Items);
            Assert.Equal(2, cart.Items.First().Quantity);
        }

        [Fact]
        public async Task AddItem_Should_Increment_Quantity_When_Item_Already_Exists()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);

            var user = new User { Id = Guid.NewGuid() };
            var product = new Product { Id = Guid.NewGuid(), Name = "Laptop", Price = 999m };

            await service.AddItem(user, product, 3);

            var result = await service.AddItem(user, product, 2);

            Assert.Equal(5, result.Quantity); 

            var cart = await db.Carts.Include(c => c.Items).FirstAsync(c => c.UserId == user.Id);
            Assert.Single(cart.Items);
            Assert.Equal(5, cart.Items.First().Quantity);
        }

        [Fact]
        public async Task AddItem_Should_Throw_When_Quantity_Is_Zero_Or_Negative()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);

            var user = new User { Id = Guid.NewGuid() };
            var product = new Product { Id = Guid.NewGuid(), Name = "Test", Price = 100 };

            await Assert.ThrowsAsync<ArgumentException>(
                () => service.AddItem(user, product, 0));

            await Assert.ThrowsAsync<ArgumentException>(
                () => service.AddItem(user, product, -1));
        }

        [Fact]
        public async Task AddItem_Should_Throw_When_User_Is_Null()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);
            var product = new Product { Id = Guid.NewGuid(), Name = "Test", Price = 100 };

            await Assert.ThrowsAsync<ArgumentNullException>(
                () => service.AddItem(null!, product, 1));
        }

        #endregion

        #region RemoveItem Tests

        [Fact]
        public async Task RemoveItem_Should_Remove_Existing_Item_And_Return_True()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);

            var user = new User { Id = Guid.NewGuid() };
            var product = new Product { Id = Guid.NewGuid(), Name = "Headphones", Price = 89.99m };

            await service.AddItem(user, product, 1);

            var removed = await service.RemoveItem(user, product.Id);

            Assert.True(removed);

            var cart = await db.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == user.Id);
            Assert.NotNull(cart);
            Assert.Empty(cart.Items);
        }

        [Fact]
        public async Task RemoveItem_Should_Return_False_When_Item_Not_Found()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);

            var user = new User { Id = Guid.NewGuid() };
            var nonExistentProductId = Guid.NewGuid();

            var removed = await service.RemoveItem(user, nonExistentProductId);

            Assert.False(removed);
        }

        #endregion

        #region GetCartProducts Tests

        [Fact]
        public async Task GetCartProducts_Should_Return_Products_With_Correct_Quantity()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);

            var user = new User { Id = Guid.NewGuid() };
            var product1 = new Product { Id = Guid.NewGuid(), Name = "Laptop", Price = 1200m, Stock = 10 };
            var product2 = new Product { Id = Guid.NewGuid(), Name = "Mouse", Price = 45m, Stock = 50 };

            await service.AddItem(user, product1, 1);
            await service.AddItem(user, product2, 3);

            var cartProducts = await service.GetCartProducts(user);

            Assert.Equal(2, cartProducts.Count);

            var laptop = cartProducts.FirstOrDefault(p => p.ProductId == product1.Id);
            var mouse = cartProducts.FirstOrDefault(p => p.ProductId == product2.Id);

            Assert.NotNull(laptop);
            Assert.Equal("Laptop", laptop.Name);
            Assert.Equal(1200m, laptop.Price);
            Assert.Equal(1, laptop.Quantity);

            Assert.NotNull(mouse);
            Assert.Equal("Mouse", mouse.Name);
            Assert.Equal(45m, mouse.Price);
            Assert.Equal(3, mouse.Quantity);
        }

        [Fact]
        public async Task GetCartProducts_Should_Return_Empty_List_When_Cart_Is_Empty()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);

            var user = new User { Id = Guid.NewGuid() };

            var result = await service.GetCartProducts(user);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetCartProducts_Should_Create_Cart_If_It_Does_Not_Exist()
        {
            var db = GetInMemoryDb();
            var service = new CartService(db);

            var user = new User { Id = Guid.NewGuid() };

            var result = await service.GetCartProducts(user);

            Assert.Empty(result); 

            var cartExists = await db.Carts.AnyAsync(c => c.UserId == user.Id);
            Assert.True(cartExists);
        }

        #endregion
    }
}