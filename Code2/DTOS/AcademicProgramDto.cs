using System;
using System.ComponentModel.DataAnnotations;

namespace Code2.DTOS
{
    public class AcademicProgramDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Program name is required.")]
        [StringLength(150, ErrorMessage = "Program name cannot be longer than 150 characters.")]
        public string ProgramName { get; set; }

        [Required(ErrorMessage = "Faculty is required.")]
        public FacultyDto Faculty { get; set; }
    }
}
