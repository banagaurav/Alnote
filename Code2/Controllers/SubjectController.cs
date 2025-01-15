using Microsoft.AspNetCore.Mvc;
using Code2.DTOS;
using Code2.Models; // Assuming your models are in this namespace
using Code2.Services.Interfaces;
using Code2.Services; // Assuming you have a service layer

namespace Code2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly MappingService _mappingService;

        public SubjectController(ISubjectService subjectService, MappingService mappingService)
        {
            _subjectService = subjectService;
            _mappingService = mappingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("Subject Only")]
        public async Task<ActionResult<SubjectOnlyDto>> GetSubjectsOnly()
        {
            var subjects = await _subjectService.GetSubjectsOnly();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubjectById(int id)
        {
            var subjectDto = await _subjectService.GetSubjectByIdAsync(id);

            if (subjectDto == null)
            {
                return NotFound(); // Return 404 if subject not found
            }

            return Ok(subjectDto); // Return 200 with subject DTO
        }

    }
}
