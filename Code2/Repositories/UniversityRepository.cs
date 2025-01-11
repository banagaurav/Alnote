using System;
using Microsoft.EntityFrameworkCore;

namespace Code2.Repositories;

public class UniversityRepository : IUniversityRepository
{
    private readonly AppDbContext _context;

    public UniversityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<University> CreateUniversityAsync(University university)
    {
        await _context.Universities.AddAsync(university);
        await _context.SaveChangesAsync();
        return university;
    }

    public async Task<IEnumerable<University>> GetAllUniversitiesAsync()
    {
        return await _context.Universities.ToListAsync();
    }
    public async Task<University> GetUniversityByIdAsync(int universityId)
    {
        return await _context.Universities.FindAsync(universityId);
    }

    public async Task<bool> DeleteUniversityAsync(int universityId)
    {
        var university = await GetUniversityByIdAsync(universityId);
        if (university == null)
            return false;

        _context.Universities.Remove(university);
        await _context.SaveChangesAsync();
        return true;
    }
}