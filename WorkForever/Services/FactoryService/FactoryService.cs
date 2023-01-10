using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WorkForever.Dtos.Factory;
using WorkForever.Models;
using WorkForever.Repositories.UnitOfWork;

namespace WorkForever.Services.FactoryService;

public class FactoryService: BaseService, IFactoryService
{
    public FactoryService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        
    }
    
    public async Task<ServiceResponse<List<GetFactoryDto>>> GetAllFactories()
    {
        var serviceResponse = new ServiceResponse<List<GetFactoryDto>>();
        var factories = await UnitOfWork.FactoryRepository.GetAllAsync();
        if (factories.IsNullOrEmpty())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "No factory found";
            return serviceResponse;
        }

        serviceResponse.Data = Mapper.Map<List<GetFactoryDto>>(factories);
        return serviceResponse;
    }
    

    public async Task<ServiceResponse<GetFactoryDto>> GetFactoryById(int id)
    {
        var serviceResponse = new ServiceResponse<GetFactoryDto>();
        var character = await UnitOfWork.FactoryRepository.FindByIdAsync(id);
        if (character == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Factory not found.";
            return serviceResponse;
        }

        serviceResponse.Data = Mapper.Map<GetFactoryDto>(character);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetFactoryDto>>> AddFactory(AddFactoryDto newFactory)
    {
        var serviceResponse = new ServiceResponse<List<GetFactoryDto>>();

        var factory = Mapper.Map<Factory>(newFactory);
        factory.CharacterId = GetUserId();
        factory.FactoryLevel = 1;
        try
        {
            await UnitOfWork.FactoryRepository.CreateAsync(factory);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Factory could not be created.";
            Console.WriteLine(ex);
            return serviceResponse;
        }

        try
        {
            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Factory could not be saved.";
            Console.WriteLine(ex);
            throw;
        }

        var characters = await UnitOfWork.CharacterRepository.GetAllAsync();
        serviceResponse.Data = Mapper.Map<List<GetFactoryDto>>(characters);
        return serviceResponse;
    }

}