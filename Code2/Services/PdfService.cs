// Services/PdfService.cs
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
            return await _context.Pdfs
                .Include(p => p.User) // Include related User data
                .Include(p => p.PdfAcademicPrograms) // Include join table
                    .ThenInclude(pap => pap.AcademicProgram) // Include AcademicProgram
                    .ThenInclude(ap => ap.Faculty) // Include Faculty
                    .ThenInclude(f => f.University) // Include University
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt,
                    UploadedBy = $"{p.User.FirstName} {p.User.LastName}", // Combine first and last name
                    AcademicPrograms = p.PdfAcademicPrograms
                .Select(pap => _mappingService.MapToAcademicProgramDto(pap.AcademicProgram))
                .ToList()
                })
                .ToListAsync();
        }

        public async Task<PdfDto> GetPdfByIdAsync(int id)
        {
            var pdf = await _context.Pdfs
                .Include(p => p.User) // Include related User data
                .Include(p => p.PdfAcademicPrograms) // Include join table
                    .ThenInclude(pap => pap.AcademicProgram) // Include AcademicProgram
                    .ThenInclude(ap => ap.Faculty) // Include Faculty
                    .ThenInclude(f => f.University)// Include University
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pdf == null)
            {
                return null; // Or throw an exception
            }

            return new PdfDto
            {
                Id = pdf.Id,
                PdfTitle = pdf.PdfTitle,
                ThumbnailPath = pdf.ThumbnailPath,
                Rating = pdf.Rating,
                Views = pdf.Views,
                UploadedAt = pdf.UploadedAt,
                UploadedBy = $"{pdf.User.FirstName} {pdf.User.LastName}", // Combine first and last name
                AcademicPrograms = pdf.PdfAcademicPrograms
                .Select(pap => _mappingService.MapToAcademicProgramDto(pap.AcademicProgram))
                .ToList()
            };
        }

        public async Task<List<PdfDto>> GetPdfsByUserIdAsync(int userId)
        {
            return await _context.Pdfs
                .Where(p => p.UserId == userId) // Filter by user ID
                .Include(p => p.PdfAcademicPrograms) // Include join table
                    .ThenInclude(pap => pap.AcademicProgram) // Include AcademicProgram
                    .ThenInclude(ap => ap.Faculty) // Include Faculty
                    .ThenInclude(f => f.University) // Include University
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt,
                    UploadedBy = $"{p.User.FirstName} {p.User.LastName}",
                    AcademicPrograms = p.PdfAcademicPrograms
                .Select(pap => _mappingService.MapToAcademicProgramDto(pap.AcademicProgram))
                .ToList()
                })
        .ToListAsync();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByRatingAsync()
        {
            var pdfs = await _context.Pdfs
                .OrderByDescending(p => p.Rating) // Sort by Rating in descending order 
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt,
                    UploadedBy = $"{p.User.FirstName} {p.User.LastName}" // Adjust for your data
                })
                .ToListAsync();

            return pdfs;
        }

        public async Task<List<PdfDto>> GetPdfsSortedByViewsAsync()
        {
            var pdfs = await _context.Pdfs
                .OrderByDescending(p => p.Views) // Sort by Views in descending order
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt,
                    UploadedBy = $"{p.User.FirstName} {p.User.LastName}" // Adjust for your data
                })
                .ToListAsync();

            return pdfs;
        }

        public async Task<List<PdfDto>> GetPdfsSortedByRecentUploadAsync()
        {
            var pdfs = await _context.Pdfs
                .OrderByDescending(p => p.UploadedAt) // Sort by UploadedAt in descending order
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt,
                    UploadedBy = $"{p.User.FirstName} {p.User.LastName}" // Adjust for your data
                })
                .ToListAsync();

            return pdfs;
        }
    }
}
