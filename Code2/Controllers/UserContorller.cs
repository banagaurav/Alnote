using Microsoft.AspNetCore.Mvc;
using Code2.DTOS;
using Code2.Services;
using System.Threading.Tasks;

namespace Code2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            if (users == null || !users.Any())
            {
                return NotFound(); // Return 404 if no users found
            }

            var userDTOs = users.Select(user => new UserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                CurrentSchoolOrCollege = user.CurrentSchoolOrCollege,
                UniversityId = user.UniversityId,
                Username = user.Username,
                Role = user.Role
            }).ToList();

            return Ok(userDTOs); // Return 200 OK with list of users
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound(); // Return 404 if user is not found
            }

            var userDTO = new UserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                CurrentSchoolOrCollege = user.CurrentSchoolOrCollege,
                UniversityId = user.UniversityId,
                Username = user.Username,
                Role = user.Role
            };

            return Ok(userDTO);  // Return the user data as a DTO
        }
    }
}
