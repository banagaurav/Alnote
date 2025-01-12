using System;
using Code2.Models;

namespace Code2.Repositories;

public interface IPdfAcademicProgramRepository
{
    Task<IEnumerable<Pdf>> GetPdfsByAcademicProgramIdAsync(int academicProgramId);
    Task<IEnumerable<AcademicProgram>> GetAcademicProgramsByPdfIdAsync(int pdfId);
    Task AddPdfAcademicProgramAsync(PdfAcademicProgram pdfAcademicProgram);
}