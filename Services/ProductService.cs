using Amrod_E_Commerce.Data;
using Amrod_E_Commerce.Data.Context;
using Amrod_E_Commerce.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Amrod_E_Commerce.Services
{
    public class ProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return product;
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error creating product: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while creating the product.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not save product due to data conflict or constraint violation.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error creating product: {ex.Message}");
                throw; // rethrow the original exception
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products
                .ToListAsync();
        }

        public async Task<Product?> GetProduct(Guid id)
        {
            return await _db.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}