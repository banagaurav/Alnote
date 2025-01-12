using Code2.Models;


namespace Code2.Repositories.Interfaces
{
    public interface IPdfRepository
    {
        Task<IEnumerable<Pdf>> GetAllPdfsAsync();
        Task<Pdf> GetPdfByIdAsync(int id);
        Task<IEnumerable<Pdf>> GetPdfsByUserIdAsync(int userId);
        Task<IEnumerable<Pdf>> GetPdfsSortedByRatingAsync();
        Task<IEnumerable<Pdf>> GetPdfsSortedByViewsAsync();
        Task<IEnumerable<Pdf>> GetPdfsSortedByRecentUploadAsync();
    }
}
