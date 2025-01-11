using System;
using Code2.DTOS;

namespace Code2.Services;

public interface IUniversityService
{
    Task<UniversityDto> CreateUniversityAsync(UniversityDto universityDto);
    Task<IEnumerable<UniversityDto>> GetAllUniversitiesAsync();
    Task<bool> DeleteUniversityAsync(int universityId);
    Task<University> GetUniversityByIdAsync(int id);
}
