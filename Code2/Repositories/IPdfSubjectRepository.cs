using Code2.Models;

namespace Code2.Repositories
{
    public interface IPdfSubjectRepository
    {
        Task<IEnumerable<Pdf>> GetPdfsBySubjectIdAsync(int subjectId);
        Task<IEnumerable<Subject>> GetSubjectsByPdfIdAsync(int pdfId);
        Task AddPdfSubjectAsync(PdfSubject pdfSubject);
        Task<Pdf> GetPdfByIdAsync(int pdfId); // Keep if needed
    }
}