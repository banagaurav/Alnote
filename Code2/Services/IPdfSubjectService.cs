using Code2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Code2.Services
{
    public interface IPdfSubjectService
    {
        Task<IEnumerable<Pdf>> GetPdfsBySubjectIdAsync(int subjectId);
        Task<IEnumerable<Subject>> GetSubjectsByPdfIdAsync(int pdfId);
        Task AddPdfSubjectAsync(int pdfId, List<int> subjectIds);
    }
}
