using System.ComponentModel.DataAnnotations;

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string CurrentSchoolOrCollege { get; set; }
    public int UniversityId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
