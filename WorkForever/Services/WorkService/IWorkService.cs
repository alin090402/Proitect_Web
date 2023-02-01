using WorkForever.Dtos.Work;
using WorkForever.Models;

namespace WorkForever.Services.WorkService;

public interface IWorkService:IBaseService
{
    public Task<ServiceResponse<WorkResultDto>> CreateWork(int FactoryId);
}