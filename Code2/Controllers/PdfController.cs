// Controllers/PdfController.cs
using Code2.DTOs;
using Code2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Code2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPdfs()
        {
            var pdfs = await _pdfService.GetAllPdfsAsync();
            return Ok(pdfs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPdfById(int id)
        {
            var pdf = await _pdfService.GetPdfByIdAsync(id);
            if (pdf == null)
            {
                return NotFound();
            }
            return Ok(pdf);
        }

        [HttpGet("TopRated")]
        public async Task<IActionResult> GetTopRatedPdfs()
        {
            var pdfs = await _pdfService.GetPdfsSortedByRatingAsync();
            return Ok(pdfs);
        }

        [HttpGet("MostViewed")]
        public async Task<IActionResult> GetMostViewedPdfs()
        {
            var pdfs = await _pdfService.GetPdfsSortedByViewsAsync();
            return Ok(pdfs);
        }

        [HttpGet("RecentUploads")]
        public async Task<IActionResult> GetRecentUploads()
        {
            var pdfs = await _pdfService.GetPdfsSortedByRecentUploadAsync();
            return Ok(pdfs);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPdfsByUserId(int userId)
        {
            var pdfs = await _pdfService.GetPdfsByUserIdAsync(userId);

            if (pdfs == null || !pdfs.Any())
            {
                return NotFound(new { message = "No PDFs found for the specified user." });
            }

            return Ok(pdfs);
        }
    }
}
