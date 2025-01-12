using Code2.Models;
using Microsoft.EntityFrameworkCore;

namespace Code2.Repositories
{
    public class PdfAcademicProgramRepository : IPdfAcademicProgramRepository
    {
        private readonly AppDbContext _context;

        public PdfAcademicProgramRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pdf>> GetPdfsByAcademicProgramIdAsync(int academicProgramId)
        {
            return await _context.PdfAcademicPrograms
                .Where(pap => pap.AcademicProgramId == academicProgramId)
                .Select(pap => pap.Pdf)
                .ToListAsync();
        }

        public async Task<IEnumerable<AcademicProgram>> GetAcademicProgramsByPdfIdAsync(int pdfId)
        {
            return await _context.PdfAcademicPrograms
                .Where(pap => pap.PdfId == pdfId)
                .Select(pap => pap.AcademicProgram)
                .ToListAsync();
        }

        public async Task AddPdfAcademicProgramAsync(PdfAcademicProgram pdfAcademicProgram)
        {
            await _context.PdfAcademicPrograms.AddAsync(pdfAcademicProgram);
            await _context.SaveChangesAsync();
        }
    }
}
