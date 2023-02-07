using AutoMapper;
using Microsoft.AspNetCore.Rewrite;
using WorkForever.Dtos.Work;
using WorkForever.Models;
using WorkForever.Repositories.UnitOfWork;

namespace WorkForever.Services.WorkService;

public class WorkService:BaseService, IWorkService
{
    public WorkService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }
    
    public async Task<ServiceResponse<WorkResultDto>> CreateWork(WorkRequestDto workRequestDto)
    {
        int factoryId = workRequestDto.FactoryId;
        var serviceResponse = new ServiceResponse<WorkResultDto>();
        int userId = GetUserId();
        var user = await UnitOfWork.UserRepository.FindByIdAsync(userId);
        if (user == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "User not found";
            return serviceResponse;
        }
        double experience = user.WorkExperience;
        var factory = await UnitOfWork.FactoryRepository.FindByIdAsync(factoryId);
        if (factory == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Factory not found";
            return serviceResponse;
        }
        var Owner = await UnitOfWork.UserRepository.FindByIdAsync(factory.UserId);
        if (Owner == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Owner not found";
            return serviceResponse;
        }
        Random random = new Random();
        int itemsCreated = Convert.ToInt32(Math.Floor((random.NextDouble() * 2 + 3) * experience));
        double moneyEarned = itemsCreated * factory.Salary;
        if (moneyEarned > Owner.Money)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Owner does not have enough money";
            return serviceResponse;
        }
        Owner.Money -= moneyEarned;
        user.Money += moneyEarned;
        user.WorkExperience += 1 / experience;
        await UnitOfWork.ItemRepository.AddItems(factory.ItemCreatedId, Owner.Id, itemsCreated);
        await UnitOfWork.SaveAsync();
        serviceResponse.Data = new WorkResultDto
        {
            ItemId = factory.ItemCreatedId,
            Quantity = itemsCreated,
            MoneyGained = moneyEarned
        };
        return serviceResponse;
    }
}