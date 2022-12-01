using Microsoft.AspNetCore.Mvc;
using WorkForever.Models;
using WorkForever.Services.CharacterService;

namespace WorkForever.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<List<Character>>>> GetAll()
    {
        return Ok(await _characterService.GetAllCharacters());
    }
    
    
}