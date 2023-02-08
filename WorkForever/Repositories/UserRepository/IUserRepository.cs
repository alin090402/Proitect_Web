using WorkForever.Dtos.User;
using WorkForever.Models;
using WorkForever.Models.Composed;

namespace WorkForever.Repositories;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    Task<Boolean> IsUsernameAvailableAsync(string username);
    Task<Boolean> IsEmailAvailableAsync(string email);
    //Task<List<UserWithEverything> > GetUsersWithEverythingAsync();
    Task<List<User> > GetUsersWithDataAsync();
    public void Delete(int id);
}