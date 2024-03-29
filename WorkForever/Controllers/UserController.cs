﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkForever.Dtos;
using WorkForever.Dtos.Factory;
using WorkForever.Dtos.User;
using WorkForever.Models;
using WorkForever.Services.UserService;

namespace WorkForever.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService factoryService)
    {
        _userService = factoryService;
    }
    
    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetAll()
    {
        return Ok(await _userService.GetAllUsers());
    }
    [HttpGet("getAllWithEverything")]
    public async Task<ActionResult<ServiceResponse<List<GetUserWithEverythingDto>>>> GetAllWithEverything()
    {
        return Ok(await _userService.GetUsersWithEverything());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetSingle(int id)
    {
        return Ok(await _userService.GetUserById(id));
    }
    [HttpGet("getCurrentUser")]
    public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetCurrentUser()
    {
        return Ok(await _userService.GetCurrentUser());
    }
    [HttpPost("addUserInfo")]
    public async Task<ActionResult<ServiceResponse<GetUserDto>>> AddUserInfo(AddUserInfoDto newUser)
    {
        return Ok(await _userService.AddUserInfo(newUser));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<GetUserDto>>> AddFactory(UpdateUserDto newUser)
    {
        return Ok(await _userService.UpdateUser(newUser));
    }
}