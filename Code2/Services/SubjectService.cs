using Code2.Models;
using Code2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code2.Services;
public class SubjectService : ISubjectService
{
    private readonly AppDbContext _context;

    public SubjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
    {
        return await _context.Subjects
            .Include(s => s.AcademicProgram)
                .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
            .ToListAsync();
    }

    public async Task<IEnumerable<Subject>> GetSubjectsOnly()
    {
        return await _context.Subjects.ToListAsync();
    }
}