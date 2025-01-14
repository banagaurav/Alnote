using Code2.DTOS;
using Code2.Repositories;

namespace Code2.Services;

public class UniversityService : IUniversityService
{
    private readonly IUniversityRepository _universityRepository;

    public UniversityService(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }

    public async Task<UniversityDto> CreateUniversityAsync(UniversityDto universityDto)
    {
        var university = new University
        {
            UniversityName = universityDto.UniversityName,
        };

        var createdUniversity = await _universityRepository.CreateUniversityAsync(university);

        return new UniversityDto
        {
            UniversityName = createdUniversity.UniversityName,
        };
    }

    public async Task<IEnumerable<UniversityDto>> GetAllUniversitiesAsync()
    {
        var universities = await _universityRepository.GetAllUniversitiesAsync();

        return universities.Select(u => new UniversityDto
        {
            Id = u.Id,
            UniversityName = u.UniversityName,
        });
    }

    // Get a university by Id
    public async Task<University> GetUniversityByIdAsync(int id)
    {
        return await _universityRepository.GetUniversityByIdAsync(id);
    }

    public async Task<bool> DeleteUniversityAsync(int universityId)
    {
        return await _universityRepository.DeleteUniversityAsync(universityId);
    }
}
