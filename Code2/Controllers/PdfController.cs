using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Code2.Models; // Namespace for your models
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PdfController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pdf
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pdf>>> GetAllPdfs()
        {
            var pdfs = await _context.Pdfs
                .Include(p => p.User) // Include related User data
                .ToListAsync();

            return Ok(pdfs);
        }

        // GET: api/Pdf/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pdf>> GetPdfById(int id)
        {
            var pdf = await _context.Pdfs
                .Include(p => p.User) // Include related User data
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pdf == null)
            {
                return NotFound(new { message = "PDF not found." });
            }

            return Ok(pdf);
        }
    }
}
