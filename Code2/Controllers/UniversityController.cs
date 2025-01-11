using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Code2.Models;
using Code2.Services;
using Code2.DTOS;

namespace Code2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUniversity([FromBody] UniversityDto universityDto)
        {
            if (universityDto == null)
                return BadRequest("University data is required.");

            try
            {
                var createdUniversity = await _universityService.CreateUniversityAsync(universityDto);
                return CreatedAtAction(nameof(CreateUniversity), new { id = createdUniversity.UniversityName }, createdUniversity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUniversities()
        {
            try
            {
                var universities = await _universityService.GetAllUniversitiesAsync();
                return Ok(universities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/university/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversityById(int id)
        {
            var university = await _universityService.GetUniversityByIdAsync(id);

            if (university == null)
            {
                return NotFound(); // If no university is found with the given id
            }

            return Ok(university); // Return the found university
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
