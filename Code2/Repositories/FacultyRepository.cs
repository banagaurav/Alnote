using Code2.Models;
using Microsoft.EntityFrameworkCore;

namespace Code2.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly AppDbContext _context;

        public FacultyRepository(AppDbContext context)
        {
            _context = context;
        }

        // Fetch all faculties
        public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
        {
            return await _context.Faculties
                .Include(f => f.University)  // Include University to avoid lazy loading issues
                .ToListAsync();
        }

        // Add a faculty
        public async Task AddAsync(Faculty faculty)
        {
            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
        }

        // Fetch faculty by id
        public async Task<Faculty> GetByIdAsync(int id)
        {
            return await _context.Faculties
                .Include(f => f.University)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }

}
