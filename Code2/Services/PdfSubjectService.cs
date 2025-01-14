using Code2.Models;
using Code2.Repositories;
namespace Code2.Services
{
    public class PdfSubjectService : IPdfSubjectService
    {
        private readonly IPdfSubjectRepository _repository;

        public PdfSubjectService(IPdfSubjectRepository repository)
        {
            _repository = repository;
        }

        // Method to get PDFs by Subject ID
        public async Task<IEnumerable<Pdf>> GetPdfsBySubjectIdAsync(int subjectId)
        {
            var pdfs = await _repository.GetPdfsBySubjectIdAsync(subjectId);
            return pdfs;
        }

        // Method to get Subjects by PDF ID
        public async Task<IEnumerable<Subject>> GetSubjectsByPdfIdAsync(int pdfId)
        {
            var subjects = await _repository.GetSubjectsByPdfIdAsync(pdfId);
            return subjects;
        }

        // Method to associate PDFs with Subjects
        public async Task AddPdfSubjectAsync(int pdfId, List<int> subjectIds)
        {
            foreach (var subjectId in subjectIds)
            {
                var pdfSubject = new PdfSubject
                {
                    PdfId = pdfId,
                    SubjectId = subjectId
                };
                await _repository.AddPdfSubjectAsync(pdfSubject);
            }
        }
    }
}
