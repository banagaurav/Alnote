using Code2.Models;
using Microsoft.EntityFrameworkCore;

namespace Code2.Repositories
{
    public class PdfSubjectRepository : IPdfSubjectRepository
    {
        private readonly AppDbContext _context;

        public PdfSubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pdf>> GetPdfsBySubjectIdAsync(int subjectId)
        {
            return await _context.PdfSubjects
                .Where(ps => ps.SubjectId == subjectId)
                .Select(ps => ps.Pdf)
                .ToListAsync();
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByPdfIdAsync(int pdfId)
        {
            return await _context.PdfSubjects
                .Where(ps => ps.PdfId == pdfId)
                .Select(ps => ps.Subject)
                .ToListAsync();
        }

        public async Task AddPdfSubjectAsync(PdfSubject pdfSubject)
        {
            await _context.PdfSubjects.AddAsync(pdfSubject);
            await _context.SaveChangesAsync();
        }

        public async Task<Pdf> GetPdfByIdAsync(int pdfId)
        {
            return await _context.Pdfs
                .FirstOrDefaultAsync(p => p.Id == pdfId);
        }
    }
}
