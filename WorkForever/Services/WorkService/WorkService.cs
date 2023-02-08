using AutoMapper;
using Microsoft.AspNetCore.Rewrite;
using WorkForever.Dtos.Work;
using WorkForever.Models;
using WorkForever.Repositories;
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
        if (user.LastWorked != null)
        {
            if (DateTime.Now.Subtract(user.LastWorked.Value).TotalMinutes < 5)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "You have to wait 5 minutes to work again";
                return serviceResponse;
            }
        }
        
        Owner.Money -= moneyEarned;
        user.Money += moneyEarned;
        user.WorkExperience += 1 / experience;
        DateTime time = DateTime.Now;
        user.LastWorked = time;
        await UnitOfWork.ItemRepository.AddItems(factory.ItemCreatedId, Owner.Id, itemsCreated);
        await UnitOfWork.WorkRecordRepository.CreateAsync(new WorkRecord
        {
            UserId = userId,
            FactoryId = factoryId,
            MoneyEarned = moneyEarned,
            ItemsEarned = itemsCreated,
            WorkedAt = time
        }); 
        await UnitOfWork.SaveAsync();
        serviceResponse.Data = new WorkResultDto
        {
            ItemId = factory.ItemCreatedId,
            Quantity = itemsCreated,
            MoneyGained = moneyEarned
        };
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetWorkRecordDto>>> GetWorkRecordsByUser(int userId)
    {
        var serviceResponse = new ServiceResponse<List<GetWorkRecordDto>>();
        var workRecords = await UnitOfWork.WorkRecordRepository.GetWorkRecordsByUser(userId);
        if (!workRecords.Any())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Work records not found";
            return serviceResponse;
        }
        serviceResponse.Data = Mapper.Map<List<GetWorkRecordDto>>(workRecords);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetWorkRecordDto>>> GetWorkRecordsByFactory(int factoryId)
    {
        var serviceResponse = new ServiceResponse<List<GetWorkRecordDto>>();
        var workRecords = await UnitOfWork.WorkRecordRepository.GetWorkRecordsByFactory(factoryId);
        if (!workRecords.Any())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Work records not found";
            return serviceResponse;
        }
        serviceResponse.Data = Mapper.Map<List<GetWorkRecordDto>>(workRecords);
        return serviceResponse;
    }
}