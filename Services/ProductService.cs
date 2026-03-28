using Amrod_E_Commerce.Data.Context;
using Amrod_E_Commerce.Data.Entities;
using Amrod_E_Commerce.ViewModels;
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

        // Lazy-loading Products
        public async Task<PagedResult<Product>> GetProductsPaged(
            int pageNumber = 1,
            int pageSize = 20,
            string? searchTerm = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            int? minStock = null,
            int? maxStock = null,
            string? orderBy = null,
            bool ascending = true)
        {
            var query = _db.Products.AsQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.Trim().ToLower();
                query = query.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    (p.Description != null && p.Description.ToLower().Contains(searchTerm))
                );
            }

            // Price filters
            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);
            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            // Ordering
            query = (orderBy?.ToLower()) switch
            {
                "name" => ascending ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name),
                "stock" => ascending ? query.OrderBy(p => p.Stock) : query.OrderByDescending(p => p.Stock),
                "price" => ascending ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name)
            };

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Product>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }
    }
}