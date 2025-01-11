using Code2.DTOS;
using Code2.Models;
using Code2.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Code2.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();

                // Map User to UserDTO
                var userDTOs = users.Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    Username = u.FullName,
                    UniversityId = u.UniversityId,
                    Role = u.Role
                });

                return userDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all users.");
                throw new InvalidOperationException("An error occurred while fetching users.");
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);

                if (user == null)
                {
                    return null;
                }

                // Map User to UserDTO
                var userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    CurrentSchoolOrCollege = user.CurrentSchoolOrCollege,
                    UniversityId = user.UniversityId,
                    Username = user.Username,
                    Role = user.Role
                };

                return userDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving user with id {id}.");
                throw new InvalidOperationException($"An error occurred while fetching the user with id {id}.");
            }
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                // Map UserDTO to User
                var user = new User
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    DateOfBirth = userDTO.DateOfBirth,
                    PhoneNumber = userDTO.PhoneNumber,
                    Email = userDTO.Email,
                    CurrentSchoolOrCollege = userDTO.CurrentSchoolOrCollege,
                    UniversityId = userDTO.UniversityId,
                    Username = userDTO.Username,
                    Role = userDTO.Role
                };

                // Hash the password before saving
                if (!string.IsNullOrWhiteSpace(userDTO.Password))
                {
                    user.Password = _passwordHasher.HashPassword(user, userDTO.Password);
                }

                // Save the user to the database
                var createdUser = await _userRepository.CreateUserAsync(user);

                // Map the created User back to UserDTO
                var createdUserDTO = new UserDTO
                {
                    UserId = createdUser.UserId,
                    FirstName = createdUser.FirstName,
                    LastName = createdUser.LastName,
                    DateOfBirth = createdUser.DateOfBirth,
                    PhoneNumber = createdUser.PhoneNumber,
                    Email = createdUser.Email,
                    CurrentSchoolOrCollege = createdUser.CurrentSchoolOrCollege,
                    UniversityId = createdUser.UniversityId,
                    Username = createdUser.Username,
                    Role = createdUser.Role
                };

                return createdUserDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user.");
                throw new InvalidOperationException($"An error occurred while creating the user: {ex.Message}", ex);
            }
        }

    }
}
