using System;
using Code2.DTOS;
using Code2.Models;

namespace Code2.Services;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    Task<UserDTO> GetUserByIdAsync(int id);
    Task<UserDTO> CreateUserAsync(UserDTO userDTO);

}
