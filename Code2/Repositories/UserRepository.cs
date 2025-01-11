using System;
using Code2.Models;
using Microsoft.EntityFrameworkCore;

namespace Code2.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    // Inject the DbContext via constructor
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // Get all users
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error saving user to the database.", ex);
        }
    }

}

