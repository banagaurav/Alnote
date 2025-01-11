using System;

namespace Code2.Repositories;

public interface IUniversityRepository
{
    Task<University> CreateUniversityAsync(University university);
    Task<IEnumerable<University>> GetAllUniversitiesAsync();
    Task<University> GetUniversityByIdAsync(int universityId);
    Task<bool> DeleteUniversityAsync(int universityId);
}

