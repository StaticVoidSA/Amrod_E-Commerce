using Amrod_E_Commerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amrod_E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("Get/{userId:guid}")]
        public async Task<IActionResult> GetCart(Guid userId)
        {
            try
            {
                var cart = await _cartService.GetCart(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem([FromQuery] Guid userId, [FromQuery] Guid productId, [FromQuery] int quantity = 1)
        {
            try
            {
                var item = await _cartService.AddItem(userId, productId, quantity);
                return Ok(item);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpDelete("RemoveItem")]
        public async Task<IActionResult> RemoveItem([FromQuery] Guid userId, [FromQuery] Guid productId)
        {
            try
            {
                var removed = await _cartService.RemoveItem(userId, productId);
                if (!removed) return NotFound("Item not found in cart.");
                return Ok("Item removed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpDelete("ClearCart/{userId:guid}")]
        public async Task<IActionResult> ClearCart(Guid userId)
        {
            try
            {
                await _cartService.ClearCart(userId);
                return Ok("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }
    }
}