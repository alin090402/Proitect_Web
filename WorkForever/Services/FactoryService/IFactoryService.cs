using WorkForever.Dtos.Factory;
using WorkForever.Models;

namespace WorkForever.Services.FactoryService;

public interface IFactoryService: IBaseService
{
    Task<ServiceResponse<List<GetFactoryDto>>> GetAllFactories();
    Task<ServiceResponse<GetFactoryDto>> GetFactoryById(int id);
    Task<ServiceResponse<List<GetFactoryDto>>> AddFactory(AddFactoryDto newFactory);
}