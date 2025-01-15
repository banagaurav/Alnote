using Code2.DTOs;
using Code2.DTOS;
using Code2.Models;
using Code2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code2.Services
{
    public class PdfService : IPdfService
    {
        private readonly AppDbContext _context;
        private readonly MappingService _mappingService;

        public PdfService(AppDbContext context, MappingService mappingService)
        {
            _context = context;
            _mappingService = mappingService;
        }

        public async Task<IEnumerable<PdfDto>> GetAllPdfsAsync()
        {
            var pdfs = await _context.Pdfs
                .Include(p => p.PdfUsers) // Include related User data
                    .ThenInclude(pu => pu.User) // Include User
                .Include(p => p.PdfSubjects) // Include relation to subjects
                    .ThenInclude(ps => ps.Subject) // Include Subject
                    .ThenInclude(s => s.AcademicProgram) // Include AcademicProgram
                    .ThenInclude(ap => ap.Faculty) // Include Faculty
                    .ThenInclude(f => f.University) // Include University
                .ToListAsync();

            return pdfs.Select(pdf => _mappingService.MapToPdfDto(pdf));
        }


        public async Task<PdfDto> GetPdfByIdAsync(int id)
        {
            var pdf = await _context.Pdfs
                .Include(p => p.PdfUsers)
                    .ThenInclude(pu => pu.User)
                .Include(p => p.PdfSubjects)
                    .ThenInclude(ps => ps.Subject)
                    .ThenInclude(s => s.AcademicProgram)
                    .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pdf == null)
            {
                return null;
            }

            // Use the mapping service to handle entity-to-DTO mapping
            return _mappingService.MapToPdfDto(pdf);
        }


        public async Task<List<PdfDto>> GetPdfsByUserIdAsync(int userId)
        {
            var pdfs = await _context.Pdfs
                .Where(p => p.PdfUsers.Any(pu => pu.UserId == userId)) // Filter by UserId in PdfUsers
                .Include(p => p.PdfSubjects)
                    .ThenInclude(ps => ps.Subject)
                    .ThenInclude(s => s.AcademicProgram)
                    .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
                .ToListAsync();

            return pdfs.Select(p => _mappingService.MapToPdfDto(p)).ToList();
        }


        public async Task<List<PdfDto>> GetPdfsSortedByRatingAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.Rating)
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt
                })
                .ToListAsync();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByViewsAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.Views)
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt
                })
                .ToListAsync();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByRecentUploadAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.UploadedAt)
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt
                })
                .ToListAsync();
        }
    }
}
