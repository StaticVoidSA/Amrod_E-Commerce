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
            // Avoid creating products with no name
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product Name is required.", nameof(product.Name));

            // Avoid creating products with no price
            if (product.Price <= 0)
                throw new ArgumentException("Product Price must be greater than zero.", nameof(product.Price));

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
                throw;
            }
        }

        public async Task<Product> UpdateProduct(Guid id, Product updatedProduct)
        {
            var existing = await _db.Products.FindAsync(id);

            if (existing == null)
                throw new KeyNotFoundException("Product not found.");

            if (string.IsNullOrWhiteSpace(updatedProduct.Name))
                throw new ArgumentException("Product Name is required.", nameof(updatedProduct.Name));

            if (updatedProduct.Price <= 0)
                throw new ArgumentException("Product Price must be greater than zero.", nameof(updatedProduct.Price));

            try
            {
                existing.Name = updatedProduct.Name;
                existing.Description = updatedProduct.Description;
                existing.ImageURL = updatedProduct.ImageURL;
                existing.Price = updatedProduct.Price;
                existing.Stock = updatedProduct.Stock;

                await _db.SaveChangesAsync();

                return existing;
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error updating product: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while updating the product.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not update product due to data conflict or constraint violation.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error updating product: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> GetProduct(Guid id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null) 
                return false;

            try
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error deleting product: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while deleting the product.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not delete product due to data conflict or constraint violation.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error deleting product: {ex.Message}");
                throw;
            }
        }
    }
}