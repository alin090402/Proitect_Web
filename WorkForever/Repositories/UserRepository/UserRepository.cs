using Microsoft.EntityFrameworkCore;
using WorkForever.Data;
using WorkForever.Dtos.Item;
using WorkForever.Dtos.User;
using WorkForever.Models;
using WorkForever.Models.Composed;

namespace WorkForever.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        var user = await _context.Users.
            FirstOrDefaultAsync(u => u.Username == username);
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

    public async Task<List<User>> GetUsersWithDataAsync()
    {
        var users = await _context.Users
            .Include(u => u.Factories)
            .ToListAsync();
        return users;
    }

    public async Task<bool> CreateInfoUser(InfoUser infoUser)
    {
        _context.InfoUsers.Add(infoUser);
        return true;
    }
    //TODO: solve this, made a workaround
    // public async Task<List<UserWithEverything>> GetUsersWithEverythingAsync()
    // {
    //     var users = await _context.Users
    //         //.Include(u => u.Factories)
    //         //.Include(u =>u.UserItems)
    //         //.ThenInclude(ui => ui.Item)
    //         .Join(_context.UserItems, u => u.Id, ui => ui.UserId, (u, ui) => new { u, ui })
    //         //.AsQueryable()
    //         .Join(_context.Items, u_ui => u_ui.ui.ItemId, i => i.Id, (u_ui, i) => new { u_ui, i })
    //         //.AsQueryable()
    //         //.Include(u_ui_i => u_ui_i.u_ui.u.UserItems)
    //         //.ThenInclude(u_ui_i => u_ui_i.Item)
    //         .GroupBy( u_ui_i => u_ui_i.u_ui.u)
    //         .Select( User_u_ui_i => new UserWithEverything()
    //         {
    //             Id = User_u_ui_i.Key.Id,
    //             Username = User_u_ui_i.Key.Username,
    //             WorkExperience = User_u_ui_i.Key.WorkExperience,
    //             Role = User_u_ui_i.Key.Role,
    //             Factories = _context.Factories.Where(f => f.UserId == User_u_ui_i.Key.Id).ToList(),
    //             
    //             ItemInventories = User_u_ui_i.Select( u_ui_i => new ItemInventory()
    //             {
    //                 Id = u_ui_i.i.Id,
    //                 Name = u_ui_i.i.Name,
    //                 Quantity = u_ui_i.u_ui.ui.Quantity
    //             }).ToList()
    //             // ItemInventories = u_ui_i.u_ui.i.Select(ui => new ItemInventory()
    //             // {
    //             //     Id = ui.ItemId,
    //             //     Name = u.i.Name,
    //             //     Quantity = ui.Quantity
    //             // }).ToList()
    //         })
    //         .ToListAsync();
    //
    //     return users;
    // }
}