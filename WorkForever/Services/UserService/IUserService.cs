﻿using WorkForever.Dtos;
using WorkForever.Dtos.User;
using WorkForever.Models;

namespace WorkForever.Services.UserService;

public interface IUserService: IBaseService
{
    Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
    Task<ServiceResponse<GetUserDto>> GetUserById(int id);
    Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedCharacter);
    Task<ServiceResponse<GetUserDto>> GetCurrentUser();
    Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
    Task<ServiceResponse<List<GetUserWithEverythingDto>>> GetUsersWithEverything();
    Task<ServiceResponse<bool>> AddUserInfo(AddUserInfoDto newUser);
}