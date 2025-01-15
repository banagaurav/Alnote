using Code2.DTOs;
using Code2.DTOS;
using Code2.Models;
using Code2.Services.Interfaces;
using Code2.Utilities;
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
                .IncludePdfRelations()
                .Select(p => _mappingService.MapToPdfDto(p)) // Use mapping service here
                .ToListAsync();
        }


        public async Task<PdfDto> GetPdfByIdAsync(int id)
        {
            var pdf = await _context.Pdfs
                .IncludePdfRelations()
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
                .IncludePdfRelations()
                .ToListAsync();

            return pdfs.Select(p => _mappingService.MapToPdfDto(p)).ToList();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByRatingAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.Rating)
                .IncludePdfRelations()
                .Select(p => _mappingService.MapToPdfDto(p)) // Use mapping service here
                .ToListAsync();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByViewsAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.Views)
                .IncludePdfRelations()
                .Select(p => _mappingService.MapToPdfDto(p)) // Use mapping service here
                .ToListAsync();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByRecentUploadAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.UploadedAt)
                .IncludePdfRelations()
                .Select(p => _mappingService.MapToPdfDto(p)) // Use mapping service here
                .ToListAsync();
        }
    }
}
