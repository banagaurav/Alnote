using Code2.DTOS;
using Code2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Code2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicProgramController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly MappingService _mappingService;

        public AcademicProgramController(AppDbContext context, MappingService mappingService)
        {
            _context = context;
            _mappingService = mappingService;
        }

        // GET: api/AcademicProgram
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicProgramDto>>> GetAcademicPrograms()
        {
            var academicPrograms = await _context.Academics
                .Include(ap => ap.Faculty) // Eager load Faculty
                .ThenInclude(f => f.University) // Eager load University related to Faculty
                .ToListAsync();

            var academicProgramDtos = academicPrograms.Select(ap => _mappingService.MapToAcademicProgramDto(ap)).ToList();

            return Ok(academicProgramDtos);
        }
    }
}
