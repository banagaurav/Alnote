namespace Code2.DTOS
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public AcademicProgramDto AcademicProgram { get; set; }
    }

}
