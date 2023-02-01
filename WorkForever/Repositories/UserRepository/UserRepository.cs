using Microsoft.EntityFrameworkCore;
using WorkForever.Data;
using WorkForever.Dtos.User;
using WorkForever.Models;

namespace WorkForever.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        return user;
    }
    public async Task<Boolean> IsUsernameAvailableAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        return user == null;
    }
    public async Task<Boolean> IsEmailAvailableAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user == null;
    }

    public async Task<List<User>> GetUsersWithFactoriesAsync()
    {
        var users = await _context.Users
            .Include(u => u.Factories)
            .ToListAsync();
        return users;
    }
}