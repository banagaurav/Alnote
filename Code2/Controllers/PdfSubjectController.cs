using Code2.Models;
using Code2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Code2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfSubjectController : ControllerBase
    {
        private readonly IPdfSubjectService _service;

        public PdfSubjectController(IPdfSubjectService service)
        {
            _service = service;
        }

        // GET: api/PdfAcademicProgram/5
        [HttpGet("{SubjectId}")]
        public async Task<ActionResult<IEnumerable<Pdf>>> GetPdfsBySubjectId(int SubjectId)
        {
            var pdfs = await _service.GetPdfsBySubjectIdAsync(SubjectId);
            if (pdfs == null || !pdfs.Any())
            {
                return NotFound("No PDFs found for the specified Subject.");
            }

            return Ok(pdfs);
        }
    }
}
