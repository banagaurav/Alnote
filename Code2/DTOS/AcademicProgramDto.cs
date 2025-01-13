using System;
using System.ComponentModel.DataAnnotations;
using Code2.Models;

namespace Code2.DTOS
{
    public class AcademicProgramDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Program name is required.")]
        [StringLength(150, ErrorMessage = "Program name cannot be longer than 150 characters.")]
        public string ProgramName { get; set; }

        public int Type { get; set; } // 0 for year and 1 for semester
        public int NoOfYears { get; set; }

        [Required(ErrorMessage = "Faculty is required.")]
        public FacultyDto Faculty { get; set; }


    }
}
