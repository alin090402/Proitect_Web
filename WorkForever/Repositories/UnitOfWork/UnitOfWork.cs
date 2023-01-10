using WorkForever.Data;
using WorkForever.Models;

namespace WorkForever.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    private DataContext _context;
    private CharacterRepository? _characterRepository;
    private UserRepository? _userRepository;
    private FactoryRepository? _factoryRepository;

    public CharacterRepository CharacterRepository
    {
        get
        {
            if (_characterRepository == null)
            {
                _characterRepository = new CharacterRepository(_context);
            }

            return _characterRepository;
        }
    }
    public UserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_context);
            }

            return _userRepository;
        }
    }

    public FactoryRepository FactoryRepository
    {
        get
        {
            if (_factoryRepository == null)
            {
                _factoryRepository = new FactoryRepository(_context);
            }

            return _factoryRepository;
        }
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}