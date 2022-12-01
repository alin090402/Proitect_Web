using Microsoft.AspNetCore.Mvc;
using WorkForever.Models;

namespace WorkForever.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<List<Character>>>> GetAll()
    {
        var response = new ServiceResponse<List<Character>>();
        return response;
    }
    
    
}