using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Required for Include
using Code2.Models;

[ApiController]
[Route("api/[controller]")]
public class FacultyController : ControllerBase
{
    private readonly AppDbContext _context;

    public FacultyController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Faculty
    [HttpGet]
    public IActionResult GetAllFaculties()
    {
        // Include University when fetching Faculties
        var faculties = _context.Faculties
            .Include(f => f.University)  // Eagerly load the associated University
            .ToList();

        return Ok(faculties);
    }
}
