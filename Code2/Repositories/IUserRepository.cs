using System.Collections.Generic;
using System.Threading.Tasks;
using Code2.Models;

namespace Code2.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> CreateUserAsync(User user);
    }
}
