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


    public async Task AddUserAsync(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        // Add the user to the repository
        await _userRepository.AddUserAsync(user);
        await _userRepository.SaveAsync();
    }


}
