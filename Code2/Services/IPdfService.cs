// Services/Interfaces/IPdfService.cs
using Code2.DTOs;

namespace Code2.Services.Interfaces
{
    public interface IPdfService
    {
        Task<IEnumerable<PdfDto>> GetAllPdfsAsync();
        Task<PdfDto> GetPdfByIdAsync(int id);
        Task<List<PdfDto>> GetPdfsSortedByRatingAsync();
        Task<List<PdfDto>> GetPdfsSortedByViewsAsync();
        Task<List<PdfDto>> GetPdfsSortedByRecentUploadAsync();
    }
}
