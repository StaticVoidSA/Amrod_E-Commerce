using Microsoft.AspNetCore.Mvc;
using Amrod_E_Commerce.Services;
using Amrod_E_Commerce.Data.Entities;

namespace Amrod_E_Commerce.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllProducts(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            string? orderBy = null,
            int? minStock = null,
            int? maxStock = null,
            bool ascending = true)
        {
            var pagedResult = await _service.GetProductsPaged(
                pageNumber, pageSize, searchTerm, minPrice, maxPrice, minStock, maxStock, orderBy, ascending);

            // IMPORTANT: For ALL AJAX requests (pagination, page size, filters), return ONLY the items partial
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_ProductGridItems", pagedResult.Items); 
            }

            // Normal browser page load (full view)
            ViewData["CurrentSearch"] = searchTerm;
            ViewData["MinPrice"] = minPrice;
            ViewData["MaxPrice"] = maxPrice;
            ViewData["OrderBy"] = orderBy;
            ViewData["Ascending"] = ascending;
            ViewData["PageSize"] = pageSize;
            ViewData["TotalItems"] = pagedResult.TotalCount;
            ViewData["ShowingFrom"] = (pageNumber - 1) * pageSize + 1;
            ViewData["ShowingTo"] = Math.Min(pageNumber * pageSize, pagedResult.TotalCount);
            ViewData["MinStock"] = minStock;
            ViewData["MaxStock"] = maxStock;

            return View("Products", pagedResult);   // Pass full PagedResult to main view
        }

        [HttpGet("get-product/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetProduct(id);
            if (product == null) 
                return NotFound();
            
            return View(product);
        }

        [HttpGet("get-product-partial/{id}")]
        public async Task<IActionResult> GetProductPartial(Guid id)
        {
            var product = await _service.GetProduct(id);
            if (product == null) return NotFound();

            return PartialView("_ProductCard", product);
        }

        [HttpGet("get-edit-product-partial/{id}")]
        public async Task<IActionResult> GetEditProductPartial(Guid id)
        {
            var product = await _service.GetProduct(id);

            if (product == null)
                return NotFound();

            return PartialView("_EditProductPartial", product);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _service.CreateProduct(product);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Product updatedProduct)
        {
            if (updatedProduct == null || id != updatedProduct.Id)
                return BadRequest("Invalid product data.");

            try
            {
                var product = await _service.UpdateProduct(id, updatedProduct);
                return Ok(product);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Product not found.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}