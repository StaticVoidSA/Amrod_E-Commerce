using Amrod_E_Commerce.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Amrod_E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TestController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _db.Products.ToList();
            return Ok(products);
        }
    }
}
