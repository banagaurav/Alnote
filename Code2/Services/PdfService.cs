using Code2.DTOs;
using Code2.DTOS;
using Code2.Models;
using Code2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Code2.Services
{
    public class PdfService : IPdfService
    {
        private readonly AppDbContext _context;
        private readonly MappingService _mappingService;

        public PdfService(AppDbContext context, MappingService mappingService)
        {
            _context = context;
            _mappingService = mappingService;
        }

        public async Task<IEnumerable<PdfDto>> GetAllPdfsAsync()
        {
            return await _context.Pdfs
                .Include(p => p.PdfUsers) // Include related User data
                    .ThenInclude(pu => pu.User) // Include User
                .Include(p => p.PdfSubjects) // Include relation to subjects
                    .ThenInclude(ps => ps.Subject) // Include Subject
                    .ThenInclude(s => s.AcademicProgram) // Include AcademicProgram
                    .ThenInclude(ap => ap.Faculty) // Include Faculty
                    .ThenInclude(f => f.University) // Include University
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt,

                    // Mapping many-to-many relation between Pdf and Subject
                    Subjects = p.PdfSubjects
                        .Select(ps => new SubjectDto
                        {
                            Id = ps.Subject.Id,
                            SubjectName = ps.Subject.SubjectName,
                            SubjectCode = ps.Subject.SubjectCode,
                            AcademicProgram = new AcademicProgramDto
                            {
                                Id = ps.Subject.AcademicProgram.Id,
                                ProgramName = ps.Subject.AcademicProgram.ProgramName,
                                NoOfYears = ps.Subject.AcademicProgram.NoOfYears,
                                Type = ps.Subject.AcademicProgram.Type,
                                Faculty = new FacultyDto
                                {
                                    Id = ps.Subject.AcademicProgram.Faculty.Id,
                                    FacultyName = ps.Subject.AcademicProgram.Faculty.FacultyName,
                                    University = new UniversityDto
                                    {
                                        Id = ps.Subject.AcademicProgram.Faculty.University.Id,
                                        UniversityName = ps.Subject.AcademicProgram.Faculty.University.UniversityName
                                    }
                                }
                            }
                        }).ToList(),

                    // Mapping many-to-many relation between Pdf and User
                    Users = p.PdfUsers
                        .Select(pu => _mappingService.MapToUserDto(pu.User))
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<PdfDto> GetPdfByIdAsync(int id)
        {
            var pdf = await _context.Pdfs
                .Include(p => p.PdfUsers)
                    .ThenInclude(pu => pu.User)
                .Include(p => p.PdfSubjects)
                    .ThenInclude(ps => ps.Subject)
                    .ThenInclude(s => s.AcademicProgram)
                    .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pdf == null)
            {
                return null;
            }

            return new PdfDto
            {
                Id = pdf.Id,
                PdfTitle = pdf.PdfTitle,
                ThumbnailPath = pdf.ThumbnailPath,
                Rating = pdf.Rating,
                Views = pdf.Views,
                UploadedAt = pdf.UploadedAt,

                // Mapping many-to-many relation between Pdf and Subject
                Subjects = pdf.PdfSubjects
                    .Select(ps => new SubjectDto
                    {
                        Id = ps.Subject.Id,
                        SubjectName = ps.Subject.SubjectName,
                        SubjectCode = ps.Subject.SubjectCode,
                        AcademicProgram = new AcademicProgramDto
                        {
                            Id = ps.Subject.AcademicProgram.Id,
                            ProgramName = ps.Subject.AcademicProgram.ProgramName,
                            Faculty = new FacultyDto
                            {
                                Id = ps.Subject.AcademicProgram.Faculty.Id,
                                FacultyName = ps.Subject.AcademicProgram.Faculty.FacultyName,
                                University = new UniversityDto
                                {
                                    Id = ps.Subject.AcademicProgram.Faculty.University.Id,
                                    UniversityName = ps.Subject.AcademicProgram.Faculty.University.UniversityName
                                }
                            }
                        }
                    }).ToList(),

                // Mapping many-to-many relation between Pdf and User
                Users = pdf.PdfUsers
                    .Select(pu => _mappingService.MapToUserDto(pu.User))
                    .ToList()
            };
        }

        public async Task<List<PdfDto>> GetPdfsByUserIdAsync(int userId)
        {
            return await _context.Pdfs
                .Where(p => p.PdfUsers.Any(pu => pu.UserId == userId)) // Filter by UserId in PdfUsers
                .Include(p => p.PdfSubjects)
                    .ThenInclude(ps => ps.Subject)
                    .ThenInclude(s => s.AcademicProgram)
                    .ThenInclude(ap => ap.Faculty)
                    .ThenInclude(f => f.University)
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt,

                    // Mapping many-to-many relation between Pdf and Subject
                    Subjects = p.PdfSubjects
                        .Select(ps => new SubjectDto
                        {
                            Id = ps.Subject.Id,
                            SubjectName = ps.Subject.SubjectName,
                            SubjectCode = ps.Subject.SubjectCode,
                            AcademicProgram = new AcademicProgramDto
                            {
                                Id = ps.Subject.AcademicProgram.Id,
                                ProgramName = ps.Subject.AcademicProgram.ProgramName,
                                Faculty = new FacultyDto
                                {
                                    Id = ps.Subject.AcademicProgram.Faculty.Id,
                                    FacultyName = ps.Subject.AcademicProgram.Faculty.FacultyName,
                                    University = new UniversityDto
                                    {
                                        Id = ps.Subject.AcademicProgram.Faculty.University.Id,
                                        UniversityName = ps.Subject.AcademicProgram.Faculty.University.UniversityName
                                    }
                                }
                            }
                        }).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByRatingAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.Rating)
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt
                })
                .ToListAsync();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByViewsAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.Views)
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt
                })
                .ToListAsync();
        }

        public async Task<List<PdfDto>> GetPdfsSortedByRecentUploadAsync()
        {
            return await _context.Pdfs
                .OrderByDescending(p => p.UploadedAt)
                .Select(p => new PdfDto
                {
                    Id = p.Id,
                    PdfTitle = p.PdfTitle,
                    ThumbnailPath = p.ThumbnailPath,
                    Rating = p.Rating,
                    Views = p.Views,
                    UploadedAt = p.UploadedAt
                })
                .ToListAsync();
        }
    }
}
