using Microsoft.EntityFrameworkCore;
using Code2.Models;
using System.Linq;

namespace Code2.Utilities
{
    public static class QueryableExtensions
    {
        public static IQueryable<Pdf> IncludePdfRelations(this IQueryable<Pdf> query)
        {
            return query.Include(p => p.PdfUsers) // Include related User data
                    .ThenInclude(pu => pu.User) // Include User
                .Include(p => p.PdfSubjects) // Include relation to subjects
                    .ThenInclude(ps => ps.Subject) // Include Subject
                    .ThenInclude(s => s.AcademicProgram) // Include AcademicProgram
                    .ThenInclude(ap => ap.Faculty) // Include Faculty
                    .ThenInclude(f => f.University); // Include University
        }
    }
}
