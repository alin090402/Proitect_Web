﻿using WorkForever.Data;
using WorkForever.Models;

namespace WorkForever.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    private DataContext _context;
    private UserRepository? _userRepository;
    private FactoryRepository? _factoryRepository;
    private ItemRepository? _itemRepository;
    private WorkRecordRepository? _workRecordRepository;
    
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

    public ItemRepository ItemRepository
    {
        get
        {
            if (_itemRepository == null)
            {
                _itemRepository = new ItemRepository(_context);
            }

            return _itemRepository;
        }
    }
    
    public WorkRecordRepository WorkRecordRepository
    {
        get
        {
            if (_workRecordRepository == null)
            {
                _workRecordRepository = new WorkRecordRepository(_context);
            }

            return _workRecordRepository;
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