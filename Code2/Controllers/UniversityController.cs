using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Code2.Models;

namespace Code2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UniversityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/University
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversities()
        {
            var universities = await _context.Universities.ToListAsync();
            return Ok(universities);
        }
    }
}
