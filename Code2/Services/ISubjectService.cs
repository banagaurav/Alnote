// Services/Interfaces/IPdfService.cs
using Code2.DTOS;
using Code2.Models;

namespace Code2.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<IEnumerable<SubjectOnlyDto>> GetSubjectsOnly();
        Task<SubjectDto> GetSubjectByIdAsync(int id);
    }
}
