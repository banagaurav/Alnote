using Code2.Models;
using Code2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Code2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfAcademicProgramController : ControllerBase
    {
        private readonly IPdfAcademicProgramService _service;

        public PdfAcademicProgramController(IPdfAcademicProgramService service)
        {
            _service = service;
        }

        // GET: api/PdfAcademicProgram/5
        [HttpGet("{academicProgramId}")]
        public async Task<ActionResult<IEnumerable<Pdf>>> GetPdfsByAcademicProgramId(int academicProgramId)
        {
            var pdfs = await _service.GetPdfsByAcademicProgramIdAsync(academicProgramId);
            if (pdfs == null || !pdfs.Any())
            {
                return NotFound("No PDFs found for the specified Academic Program.");
            }

            return Ok(pdfs);
        }
    }
}
