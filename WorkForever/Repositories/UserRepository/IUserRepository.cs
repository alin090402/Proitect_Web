using WorkForever.Models;

namespace WorkForever.Repositories;

public interface IUserRepository: IGenericRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    Task<Boolean> IsUsernameAvailableAsync(string username);
    Task<Boolean> IsEmailAvailableAsync(string email);
    public void Delete(int id);
}