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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _service.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _service.CreateProduct(product);
            return Ok(result);
        }
    }
}