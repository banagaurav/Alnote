using Microsoft.AspNetCore.Mvc;
using Code2.Services;  // Adjust based on your actual namespace
using Code2.Models;
using Code2.DTOS;    // Adjust based on your actual namespace

namespace Code2.Controllers
{
    // Inject IUserService via constructor
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest("Invalid user data.");

            try
            {
                var createdUser = await _userService.CreateUserAsync(userDTO);

                // Return the created user with the UserId assigned by the database
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while creating the user: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            try
            {
                var isDeleted = await _universityService.DeleteUniversityAsync(id);

                if (!isDeleted)
                    return NotFound($"University with ID {id} not found.");

                return NoContent(); // HTTP 204: No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
