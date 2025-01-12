using System;
using Code2.Models;

namespace Code2.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<IEnumerable<User>> GetAllUsersAsync();  // Optional for getting all users
    Task AddUserAsync(User user);  // Optional for adding users
}
