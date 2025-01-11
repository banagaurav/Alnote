
using Code2.Models;

namespace Code2.Services;

public interface IFacultyService
{
    Task<IEnumerable<Faculty>> GetAllFacultiesAsync();
    Task CreateFacultyAsync(Faculty faculty);
    Task<Faculty> GetFacultyByIdAsync(int id);
}
