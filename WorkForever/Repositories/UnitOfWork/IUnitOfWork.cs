using Microsoft.EntityFrameworkCore;

namespace WorkForever.Repositories.UnitOfWork;

public interface IUnitOfWork
{
    public UserRepository UserRepository { get; }
    public FactoryRepository FactoryRepository { get; }
    public ItemRepository ItemRepository { get; }
    public void Save();
    public Task SaveAsync();
}