using Amrod_E_Commerce.Data.Context;
using Amrod_E_Commerce.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Amrod_E_Commerce.Services
{
    public class CartService
    {
        private readonly AppDbContext _db;

        public CartService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Cart> GetOrCreateCart(Guid userId)
        {
            try
            {
                var cart = await _db.Carts
                    .Include(c => c.Items)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (cart != null)
                    return cart;

                cart = new Cart { UserId = userId };
                _db.Carts.Add(cart);
                await _db.SaveChangesAsync();

                return cart;
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error getting or creating cart: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while accessing the cart.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not create cart due to a data conflict.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetOrCreateCart: {ex.Message}");
                throw;
            }
        }

        public async Task<CartItem> AddItem(Guid userId, Guid productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            try
            {
                var cart = await GetOrCreateCart(userId);

                var product = await _db.Products.FindAsync(productId);
                if (product == null)
                    throw new InvalidOperationException("Product not found.");

                var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                
                if (existingItem != null)
                    existingItem.Quantity += quantity;
                else
                {
                    existingItem = new CartItem
                    {
                        CartId = cart.Id,
                        ProductId = productId,
                        Quantity = quantity,
                        Price = product.Price
                    };
                    cart.Items.Add(existingItem);
                }

                await _db.SaveChangesAsync();
                return existingItem;
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error adding item to cart: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while adding item to cart.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not add item to cart due to a data conflict.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in AddItem: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> RemoveItem(Guid userId, Guid productId)
        {
            try
            {
                var cart = await GetOrCreateCart(userId);
                var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                if (item == null) return false;

                _db.CartItems.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error removing item from cart: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while removing item from cart.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not remove item from cart due to a data conflict.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in RemoveItem: {ex.Message}");
                throw;
            }
        }

        public async Task<Cart> GetCart(Guid userId)
        {
            try
            {
                return await GetOrCreateCart(userId);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in GetCart: {ex.Message}");
                throw;
            }
        }

        public async Task ClearCart(Guid userId)
        {
            try
            {
                var cart = await GetOrCreateCart(userId);
                _db.CartItems.RemoveRange(cart.Items);
                await _db.SaveChangesAsync();
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error clearing cart: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while clearing the cart.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not clear cart due to a data conflict.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error in ClearCart: {ex.Message}");
                throw;
            }
        }
    }
}