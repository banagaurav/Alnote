using Code2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly MappingService _mappingService;

    public FacultyController(AppDbContext context, MappingService mappingService)
    {
        _context = context;
        _mappingService = mappingService;
    }

    [HttpGet]
    public IActionResult GetAllFaculties()
    {
        var faculties = _context.Faculties
            .Include(f => f.University)
            .ToList();

        var facultyDtos = faculties.Select(f => _mappingService.MapToFacultyDto(f)).ToList();
        return Ok(facultyDtos);
    }
}
