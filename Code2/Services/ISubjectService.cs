// Services/Interfaces/IPdfService.cs
using Code2.Models;

namespace Code2.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<IEnumerable<Subject>> GetSubjectsOnly();
    }
}
