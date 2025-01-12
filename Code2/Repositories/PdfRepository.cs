using Code2.Models;
using Code2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code2.Repositories
{
    public class PdfRepository : IPdfRepository
    {
        private readonly AppDbContext _context;

        public PdfRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pdf>> GetAllPdfsAsync()
        {
            return await _context.Pdfs
                .Include(p => p.User)
                .Include(p => p.PdfAcademicPrograms)
                    .ThenInclude(pap => pap.AcademicProgram)
                    .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
                .ToListAsync();
        }

        public async Task<Pdf> GetPdfByIdAsync(int id)
        {
            return await _context.Pdfs
                .Include(p => p.User)
                .Include(p => p.PdfAcademicPrograms)
                    .ThenInclude(pap => pap.AcademicProgram)
                    .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pdf>> GetPdfsByUserIdAsync(int userId)
        {
            return await _context.Pdfs
                .Where(p => p.UserId == userId)
                .Include(p => p.PdfAcademicPrograms)
                    .ThenInclude(pap => pap.AcademicProgram)
                    .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pdf>> GetPdfsSortedByRatingAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.Rating)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pdf>> GetPdfsSortedByViewsAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.Views)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pdf>> GetPdfsSortedByRecentUploadAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.UploadedAt)
                .ToListAsync();
        }
    }
}
