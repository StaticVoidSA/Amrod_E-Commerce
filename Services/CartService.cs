using Amrod_E_Commerce.Data.Context;
using Amrod_E_Commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amrod_E_Commerce.Services
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductWithCartInfo
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
    }

    public class CartDto
    {
        public Guid Id { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
    }

    public class CartService
    {
        private readonly AppDbContext _db;

        public CartService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Cart> GetOrCreateCartForUserAsync(User user)
        {
            var cart = await _db.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart != null) {
                return cart;
            }


            cart = new Cart
            {
                UserId = user.Id,
                Items = new List<CartItem>()
            };

            _db.Carts.Add(cart);

            try
            {
                await _db.SaveChangesAsync();
                return cart;
            }
            catch (DbUpdateException)
            {
                return await _db.Carts
                    .Include(c => c.Items)
                    .FirstAsync(c => c.UserId == user.Id);
            }
        }

        public async Task<CartItem> AddItem(User user, Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (user?.Id == null)
                throw new ArgumentNullException(nameof(user));

            var cart = await GetOrCreateCartForUserAsync(user);

            if (cart == null)
                throw new InvalidOperationException("Failed to retrieve cart.");

            if (cart.Items == null)
                cart.Items = new List<CartItem>();

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                _db.Entry(existingItem).State = EntityState.Modified;
            }
            else
            {
                existingItem = new CartItem
                {
                    Id = Guid.NewGuid(),           
                    ProductId = product.Id,
                    CartId = cart.Id,              
                    Quantity = quantity,
                    Price = product.Price
                };

                cart.Items.Add(existingItem);
                _db.Entry(existingItem).State = EntityState.Added;   
            }

            await _db.SaveChangesAsync();

            return existingItem;
        }

        public async Task<int> GetCartItemCountAsync(User user)
        {
            var cart = await GetOrCreateCartForUserAsync(user);
            return cart.Items?.Sum(i => i.Quantity) ?? 0;
        }

        public async Task<bool> RemoveItem(User user, Guid productId)
        {
            var cart = await GetOrCreateCartForUserAsync(user);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            
            if (item == null) 
                return false;

            _db.CartItems.Remove(item);
            await _db.SaveChangesAsync();
            
            return true;
        }

        public async Task ClearCart(User user)
        {
            var cart = await GetOrCreateCartForUserAsync(user);
            _db.CartItems.RemoveRange(cart.Items);
            await _db.SaveChangesAsync();
        }

        public async Task<Cart> GetCart(User user)
        {
            return await GetOrCreateCartForUserAsync(user);
        }

        public async Task<List<ProductWithCartInfo>> GetCartProducts(User user)
        {
            // Try to get the cart with items and their products
            var cart = await _db.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null)
            {
                // Cart doesn't exist yet → create it
                cart = new Cart
                {
                    UserId = user.Id,
                    Items = new List<CartItem>()
                };

                _db.Carts.Add(cart);
                await _db.SaveChangesAsync(); // Save to generate CartId
            }

            // Project each cart item into a product-like DTO
            var result = cart.Items
                .Where(ci => ci.Product != null) // Only include items with products
                .Select(ci => new ProductWithCartInfo
                {
                    CartId = cart.Id,
                    ProductId = ci.Product.Id,
                    Name = ci.Product.Name,
                    Price = ci.Product.Price,
                    Stock = ci.Product.Stock,
                    Quantity = ci.Quantity
                })
                .ToList();

            return result;
        }
    }
}