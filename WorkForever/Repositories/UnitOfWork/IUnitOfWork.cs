using Microsoft.EntityFrameworkCore;

namespace WorkForever.Repositories.UnitOfWork;

public interface IUnitOfWork
{
    public CharacterRepository CharacterRepository { get; }
    public void Save();
    public Task SaveAsync();
}