using Code2.DTOs;
using Code2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Code2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfAcademicProgramController : ControllerBase
    {
        private readonly IPdfAcademicProgramRepository _repository;

        public PdfAcademicProgramController(IPdfAcademicProgramRepository repository)
        {
            _repository = repository;
        }

        // GET api/pdfacademicprogram/academicProgram/{academicProgramId}
        [HttpGet("academicProgram/{academicProgramId}")]
        public async Task<ActionResult<IEnumerable<PdfDto>>> GetPdfsByAcademicProgram(int academicProgramId)
        {
            var pdfs = await _repository.GetPdfsByAcademicProgramIdAsync(academicProgramId);

            if (pdfs == null || !pdfs.Any())
            {
                return NotFound();  // No PDFs found for the academic program
            }

            var pdfDtos = pdfs.Select(pdf => new PdfDto
            {
                Id = pdf.Id,
                PdfTitle = pdf.PdfTitle,
            }).ToList();

            return Ok(pdfDtos);  // Return the PDFs as DTOs
        }
    }
}
