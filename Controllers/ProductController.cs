using Microsoft.AspNetCore.Mvc;
using Amrod_E_Commerce.Services;
using Amrod_E_Commerce.Data.Entities;

namespace Amrod_E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("get-product/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetProduct(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _service.CreateProduct(product);
            return Ok(result);
        }
    }
}