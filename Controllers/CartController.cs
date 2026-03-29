using Amrod_E_Commerce.Data.Entities;
using Amrod_E_Commerce.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Amrod_E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly ProductService _productService;
        private readonly UserManager<User> _userManager;

        public CartController(CartService cartService, UserManager<User> userManager, ProductService productService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _productService = productService;
        }

        private async Task<User?> GetAuthenticatedUser()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
                return null;

            return await _userManager.GetUserAsync(User);
        }

        private IActionResult RedirectToLogin() => Redirect("/User/Login");

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem([FromQuery] Guid productId, [FromQuery] int quantity = 1)
        {
            var user = await GetAuthenticatedUser();
            if (user == null)
                return Unauthorized("Please log in to add items to your cart.");   // Changed from Redirect

            var product = await _productService.GetProduct(productId);

            if (product == null)
                return NotFound("Product not found.");

            try
            {
                var cartItem = await _cartService.AddItem(user, product, quantity);

                return Ok(new
                {
                    cartItem.Id,
                    cartItem.ProductId,
                    cartItem.Quantity,
                    cartItem.Price
                });
            }
            catch (Exception ex)
            {
                // Log the real error (check your console, logs, or Application Insights)
                Console.Error.WriteLine($"Could not add item to cart: {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);   // ← Add this line

                return StatusCode(500, new
                {
                    message = "Could not add item to cart.",
                    detail = ex.Message
                });
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCartCount()
        {
            var user = await GetAuthenticatedUser();
            if (user == null)
                return Ok(new { count = 0 });

            var count = await _cartService.GetCartItemCountAsync(user);
            return Ok(new { count });
        }

        [HttpDelete("RemoveItem")]
        public async Task<IActionResult> RemoveItem([FromQuery] Guid productId)
        {
            var user = await GetAuthenticatedUser();

            if (user == null)
                return RedirectToLogin();

            try
            {
                var removed = await _cartService.RemoveItem(user, productId);
                
                if (!removed) 
                    return NotFound("Item not found in cart.");

                return Ok("Item removed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpDelete("ClearCart")]
        public async Task<IActionResult> ClearCart()
        {
            var user = await GetAuthenticatedUser();
            if (user == null)
                return RedirectToLogin();

            try
            {
                await _cartService.ClearCart(user);
                return Ok("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart()
        {
            var user = await GetAuthenticatedUser();

            if (user == null)
                return RedirectToAction("Login", "User"); // redirect to login page

            try
            {
                var cart = await _cartService.GetCart(user);

                return View("Cart", cart.Items); 
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet("GetCartProducts")]
        public async Task<IActionResult> GetCartProducts()
        {
            var user = await GetAuthenticatedUser();

            if (user == null)
                return RedirectToAction("Login", "User"); // redirect to login page

            try
            {
                var products = await _cartService.GetCartProducts(user);

                ViewData["UserFullName"] = $"{user.FirstName} {user.LastName}";

                return View("Cart", products);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}