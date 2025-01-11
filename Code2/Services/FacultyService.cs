using Code2.DTOS;
using Code2.Models;
using Code2.Repositories;
using Microsoft.Extensions.Logging;

namespace Code2.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
        {
            return await _facultyRepository.GetAllFacultiesAsync();
        }

        public async Task CreateFacultyAsync(Faculty faculty)
        {
            try
            {
                await _facultyRepository.AddAsync(faculty);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error saving faculty.", ex);
            }
        }

        public async Task<Faculty> GetFacultyByIdAsync(int id)
        {
            return await _facultyRepository.GetByIdAsync(id);
        }
    }

}
