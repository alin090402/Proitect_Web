using Microsoft.EntityFrameworkCore;
using WorkForever.Data;
using WorkForever.Models;

namespace WorkForever.Repositories;

public class WorkRecordRepository: GenericRepository<WorkRecord>, IWorkRecordRepository
{
    public WorkRecordRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<WorkRecord>> GetWorkRecordsByUser(int userId)
    {
        var workRecords = await _context.WorkRecords
            .Where(wr => wr.UserId == userId)
            .ToListAsync();
        return workRecords;
    }

    public async Task<List<WorkRecord>> GetWorkRecordsByFactory(int factoryId)
    {
        var workRecords = await _context.WorkRecords
            .Where(wr => wr.FactoryId == factoryId)
            .ToListAsync();
        return workRecords;
    }
}