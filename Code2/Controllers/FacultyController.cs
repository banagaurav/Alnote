using Microsoft.AspNetCore.Mvc;
using Code2.Services;  // Adjust based on your actual namespace
using Code2.DTOS;     // Adjust based on your actual namespace
using Code2.Models;   // Adjust based on your actual namespace

namespace Code2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        private readonly IUniversityService _universityService;  // Service to get University
        private readonly MappingService _mappingService;  // Mapping Service

        public FacultyController(IFacultyService facultyService, IUniversityService universityService, MappingService mappingService)
        {
            _facultyService = facultyService;
            _universityService = universityService;
            _mappingService = mappingService;
        }

        // GET: api/faculty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyDto>>> GetAllFaculties()
        {
            try
            {
                var faculties = await _facultyService.GetAllFacultiesAsync();

                // Map faculties to DTOs
                var facultyDtos = faculties.Select(f => _mappingService.MapToFacultyDto(f)).ToList();

                return Ok(facultyDtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while retrieving faculties: {ex.Message}");
            }
        }

        // POST: api/faculty
        [HttpPost]
        public async Task<ActionResult<FacultyDto>> AddFaculty([FromBody] CreateFacultyDto createFacultyDto)
        {
            if (createFacultyDto == null)
                return BadRequest("Invalid data.");

            try
            {
                // Retrieve the University based on UniversityId
                var university = await _universityService.GetUniversityByIdAsync(createFacultyDto.UniversityId);
                if (university == null)
                {
                    return BadRequest("University not found.");
                }

                // Create Faculty entity and associate University
                var faculty = new Faculty
                {
                    FacultyName = createFacultyDto.FacultyName,
                    University = university // Set the University using UniversityId
                };

                // Save the Faculty entity
                await _facultyService.CreateFacultyAsync(faculty);

                // Map saved faculty to FacultyDto
                var facultyDto = _mappingService.MapToFacultyDto(faculty);

                // Return the created FacultyDto
                return CreatedAtAction(nameof(GetFacultyById), new { id = facultyDto.Id }, facultyDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while adding the faculty: {ex.Message}");
            }
        }

        // GET: api/faculty/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyDto>> GetFacultyById(int id)
        {
            var faculty = await _facultyService.GetFacultyByIdAsync(id);

            if (faculty == null)
                return NotFound();

            var facultyDto = _mappingService.MapToFacultyDto(faculty);

            return Ok(facultyDto);
        }
    }
}
