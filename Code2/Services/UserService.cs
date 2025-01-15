using Code2.DTOS;
using Code2.Models;
using Code2.Repositories;
using Code2.Services;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly MappingService _mappingService;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUserRepository userRepository, MappingService mappingService, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _mappingService = mappingService;
        _passwordHasher = passwordHasher;
    }

    public async Task<List<UserDTO>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(user => _mappingService.MapToUserDto(user)).ToList();
    }
    public async Task<UserDTO> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        return _mappingService.MapToUserDto(user);
    }


    public async Task<User> CreateUserAsync(UserCreateDto userCreateDto)
    {
        // Try to parse the DateOfBirth string to DateTime
        DateTime dateOfBirth;
        if (!DateTime.TryParse(userCreateDto.DateOfBirth, out dateOfBirth))
        {
            // Handle invalid date format if necessary (return a BadRequest or error message)
            throw new ArgumentException("Invalid date format for DateOfBirth.");
        }

        var user = new User
        {
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            DateOfBirth = dateOfBirth,  // Successfully converted to DateTime
            PhoneNumber = userCreateDto.PhoneNumber,
            Email = userCreateDto.Email,
            CurrentSchoolOrCollege = userCreateDto.CurrentSchoolOrCollege,
            UniversityId = userCreateDto.UniversityId,
            Username = userCreateDto.Username,
            Password = userCreateDto.Password, // No hashing for now
            Role = "Client"
        };

        return await _userRepository.CreateUserAsync(user);
    }

}
