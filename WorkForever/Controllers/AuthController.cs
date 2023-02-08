using Microsoft.AspNetCore.Mvc;
using WorkForever.Dtos.User;
using WorkForever.Models;
using WorkForever.Repositories.UnitOfWork;
using WorkForever.Services.AuthService;

namespace WorkForever.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto user)
    {
        var response = await _authService.RegisterAsync(user);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto user)
    {
        var response = await _authService.LoginAsync(user);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}