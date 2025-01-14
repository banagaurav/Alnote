using Microsoft.AspNetCore.Mvc;
using Code2.DTOS;
using Code2.Models; // Assuming your models are in this namespace
using Code2.Services.Interfaces;
using Code2.Services; // Assuming you have a service layer

namespace Code2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly MappingService _mappingService;

        public SubjectController(ISubjectService subjectService, MappingService mappingService)
        {
            _subjectService = subjectService;
            _mappingService = mappingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            var subjectDtos = subjects.Select(_mappingService.MapToSubjectDto).ToList();
            return Ok(subjectDtos);
        }

        // private SubjectDto MapToSubjectDto(Subject subject)
        // {
        //     return new SubjectDto
        //     {
        //         Id = subject.Id,
        //         SubjectName = subject.SubjectName,
        //         SubjectCode = subject.SubjectCode,
        //         AcademicProgram = new AcademicProgramDto
        //         {
        //             Id = subject.AcademicProgram.Id,
        //             ProgramName = subject.AcademicProgram.ProgramName,
        //             NoOfYears = subject.AcademicProgram.NoOfYears,
        //             Type = subject.AcademicProgram.Type,
        //             Faculty = new FacultyDto
        //             {
        //                 Id = subject.AcademicProgram.Faculty.Id,
        //                 FacultyName = subject.AcademicProgram.Faculty.FacultyName,
        //                 University = new UniversityDto
        //                 {
        //                     Id = subject.AcademicProgram.Faculty.University.Id,
        //                     UniversityName = subject.AcademicProgram.Faculty.University.UniversityName
        //                 }
        //             }
        //         }
        //     };
        // }
    }
}
