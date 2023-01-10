using Microsoft.EntityFrameworkCore;
using WorkForever.Data;
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
    public void Delete(int id)
    {
        var user = _context.Users.Find(id);
        if(user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("User not found");
        }
    }
}