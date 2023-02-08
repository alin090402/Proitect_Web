using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WorkForever.Data;
using WorkForever.Helpers.Exceptions;
using WorkForever.Models.Base;

namespace WorkForever.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DataContext _context;
    protected readonly DbSet<TEntity> _table;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var allItems = await _table.AsNoTracking().ToListAsync();
        return allItems;
    }

    public IQueryable<TEntity> GetAllAsQueryable()
    {
        return _table.AsQueryable();
        // return _table.AsNoTracking();

        //var entityList = _table.ToList();
        //var entityListFiltered1 = entityList.Where(x => x.Id.ToString() != "");
        //var entityListFiltered2 = _table.Where(x => x.Id.ToString() != "");


        //// better version 
        //// select * from entity where Id is not null
        //var entityListFiltered3 = _table.Where(x => x.Id.ToString() != "").ToList();
    }

    // create
    public void Create(TEntity entity)
    {
        _table.Add(entity);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
    }

    public void CreateRange(IEnumerable<TEntity> entities)
    {
        _table.AddRange(entities);
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        await _table.AddRangeAsync(entities);
    }

    // update
    public void Update(TEntity entity)
    {
        _table.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _table.UpdateRange(entities);
    }

    // delete

    public void Delete(int id)
    {
        var entity = _table.Find(id);
        if (entity != null)
        {
            _table.Remove(entity);
        }
        else throw new DataNotFoundException("Entity not found");
    }

    public void Delete(TEntity entity)
    {
        _table.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _table.RemoveRange(entities);
    }

    // find
    public TEntity? FindById(object id)
    {
        return _table.FirstOrDefault(x => x.Id.Equals(id));
    }

    public async Task<TEntity?> FindByIdAsync(object id)
    {
        return await _table.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    // save

    public bool Save()
    {
        try
        {
            return _context.SaveChanges() > 0;
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex);
        }
        return false;
    }

    public async Task<bool> SaveAsync()
    {
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex);
        }
        return false;
    }
}