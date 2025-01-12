using System;
using Code2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code2.Services
{
    public interface IPdfAcademicProgramService
    {
        Task<IEnumerable<Pdf>> GetPdfsByAcademicProgramIdAsync(int academicProgramId);
        Task<IEnumerable<AcademicProgram>> GetAcademicProgramsByPdfIdAsync(int pdfId);
        Task AddPdfAcademicProgramAsync(int pdfId, List<int> academicProgramIds);
    }
}
