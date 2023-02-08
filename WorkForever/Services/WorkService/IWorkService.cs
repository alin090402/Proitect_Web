using WorkForever.Dtos.Work;
using WorkForever.Models;

namespace WorkForever.Services.WorkService;

public interface IWorkService:IBaseService
{
    public Task<ServiceResponse<WorkResultDto>> CreateWork(WorkRequestDto workRequestDto);
    Task<ServiceResponse<List<GetWorkRecordDto>>> GetWorkRecordsByUser(int userId);
    Task<ServiceResponse<List<GetWorkRecordDto>>> GetWorkRecordsByFactory(int factoryId);
}