using Amrod_E_Commerce.Data.Entities;
using Amrod_E_Commerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amrod_E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User object is null.");

                var createdUser = await _userService.CreateUser(user);
                return Ok(createdUser);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpGet("Get/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                    return NotFound($"User with Id {id} not found.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetUserByEmail(email);
                if (user == null)
                    return NotFound($"User with Email {email} not found.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _userService.DeleteUser(id);
                if (!deleted)
                    return NotFound($"User with Id {id} not found.");

                return Ok($"User with Id {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }
    }
}