using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WorkForever.Dtos.User;
using WorkForever.Models;
using WorkForever.Models.Composed;
using WorkForever.Repositories.UnitOfWork;

namespace WorkForever.Services.UserService;

public class UserService : BaseService, IUserService
{
    public UserService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
    {
        var serviceResponse = new ServiceResponse<List<GetUserDto>>();
        var Users = await UnitOfWork.UserRepository.GetAllAsync();
        if (Users.IsNullOrEmpty())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "No Users found";
            return serviceResponse;
        }

        serviceResponse.Data = Mapper.Map<List<GetUserDto>>(Users);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserWithEverythingDto>>> GetUsersWithEverything()
    {
        var serviceResponse = new ServiceResponse<List<GetUserWithEverythingDto>>();
        var Users = await UnitOfWork.UserRepository.GetUsersWithDataAsync();
        
        if (Users.IsNullOrEmpty())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "No Users found";
            return serviceResponse;
        }
        // For each user, get his items with Quantity
        var UsersWithEverything = Mapper.Map<List<UserWithEverything>>(Users);
        foreach (var user in UsersWithEverything)
        {
            var inventory = await UnitOfWork.ItemRepository.GetInventoryOfUser(user.Id);
            user.ItemInventories = inventory;
        }
        
        serviceResponse.Data = Mapper.Map<List<GetUserWithEverythingDto>>(UsersWithEverything);
        return serviceResponse;
    }
    public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
    {
        var serviceResponse = new ServiceResponse<GetUserDto>();
        var User = await UnitOfWork.UserRepository.FindByIdAsync(id);
        if (User == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "User not found.";
            return serviceResponse;
        }

        serviceResponse.Data = Mapper.Map<GetUserDto>(User);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
    {
        var serviceResponse = new ServiceResponse<GetUserDto>();
        var user = Mapper.Map<User>(updatedUser);

        var userInDatabase = await UnitOfWork.UserRepository.FindByIdAsync(user.Id);
        if (userInDatabase == null || userInDatabase.Id != GetUserId())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "User can only be modified by it's owner";
            return serviceResponse;
        }

        try
        {
            Mapper.Map<UpdateUserDto, User>(updatedUser, userInDatabase);
            await UnitOfWork.SaveAsync();
            serviceResponse.Data = Mapper.Map<GetUserDto>(userInDatabase);
            return serviceResponse;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "User could not be updated.";
            Console.WriteLine(ex);
            return serviceResponse;
        }
    }

    public Task<ServiceResponse<GetUserDto>> GetCurrentUser()
    {
        return GetUserById(GetUserId());
    }

    public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetUserDto>>();
        try
        {
            UnitOfWork.UserRepository.Delete(id);
            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "User could not be deleted.";
            Console.WriteLine(ex);
            return serviceResponse;
        }

        var Users = await UnitOfWork.UserRepository.GetAllAsync();
        serviceResponse.Data = Mapper.Map<List<GetUserDto>>(Users);
        return serviceResponse;
    }
}