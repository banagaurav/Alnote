using Code2.DTOS;
using Code2.Models;
using Code2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code2.Services;
public class SubjectService : ISubjectService
{
    private readonly AppDbContext _context;
    private readonly MappingService _mappingService;

    public SubjectService(AppDbContext context, MappingService mappingService)
    {
        _context = context;
        _mappingService = mappingService;
    }

    public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
    {
        var subjects = await _context.Subjects
            .Include(s => s.AcademicProgram)
                .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
            .ToListAsync();

        // Add null checks for related entities to prevent NullReferenceException
        var subjectDtos = subjects.Select(subject => _mappingService.MapToSubjectDto(subject)).ToList();

        return subjectDtos;
    }
    public async Task<IEnumerable<SubjectOnlyDto>> GetSubjectsOnly()
    {
        var subjects = await _context.Subjects.ToListAsync();

        // Use the MapToSubjectOnlyDto method from the MappingService
        var subjectDtos = subjects.Select(subject => _mappingService.MapToSubjectOnlyDto(subject)).ToList();

        return subjectDtos;
    }

    public async Task<SubjectDto> GetSubjectByIdAsync(int id)
    {
        var subject = await _context.Subjects
            .Include(s => s.AcademicProgram)
                .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (subject == null)
        {
            return null; // Or throw an exception if you prefer
        }

        return _mappingService.MapToSubjectDto(subject); // Map to DTO
    }


}
