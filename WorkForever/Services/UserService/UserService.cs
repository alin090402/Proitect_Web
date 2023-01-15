using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WorkForever.Dtos.User;
using WorkForever.Models;
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

    public async Task<ServiceResponse<List<GetUserWithFactoriesDto>>> GetUsersWithFactories()
    {
        var serviceResponse = new ServiceResponse<List<GetUserWithFactoriesDto>>();
        var Users = await UnitOfWork.UserRepository.GetUsersWithFactoriesAsync();
        if (Users.IsNullOrEmpty())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "No Users found";
            return serviceResponse;
        }
        serviceResponse.Data = Mapper.Map<List<GetUserWithFactoriesDto>>(Users);
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