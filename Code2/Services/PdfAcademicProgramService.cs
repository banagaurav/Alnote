using Code2.Models;
using Code2.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code2.Services
{
    public class PdfAcademicProgramService : IPdfAcademicProgramService
    {
        private readonly IPdfAcademicProgramRepository _repository;

        public PdfAcademicProgramService(IPdfAcademicProgramRepository repository)
        {
            _repository = repository;
        }

        // Method to get PDFs by Academic Program ID
        public async Task<IEnumerable<Pdf>> GetPdfsByAcademicProgramIdAsync(int academicProgramId)
        {
            var pdfs = await _repository.GetPdfsByAcademicProgramIdAsync(academicProgramId);
            return pdfs;
        }

        // Method to get Academic Programs by PDF ID
        public async Task<IEnumerable<AcademicProgram>> GetAcademicProgramsByPdfIdAsync(int pdfId)
        {
            var academicPrograms = await _repository.GetAcademicProgramsByPdfIdAsync(pdfId);
            return academicPrograms;
        }

        // Method to associate PDFs with Academic Programs (same as before)
        public async Task AddPdfAcademicProgramAsync(int pdfId, List<int> academicProgramIds)
        {
            foreach (var academicProgramId in academicProgramIds)
            {
                var pdfAcademicProgram = new PdfAcademicProgram
                {
                    PdfId = pdfId,
                    AcademicProgramId = academicProgramId
                };

                await _repository.AddPdfAcademicProgramAsync(pdfAcademicProgram);
            }
        }
    }
}
