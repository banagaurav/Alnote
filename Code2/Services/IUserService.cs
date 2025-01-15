using System.Collections.Generic;
using System.Threading.Tasks;
using Code2.DTOS;
using Code2.Models;

namespace Code2.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);

        Task AddUserAsync(User user);
    }
}
