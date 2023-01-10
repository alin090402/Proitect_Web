using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkForever.Dtos.Character;
using WorkForever.Dtos.Factory;
using WorkForever.Models;
using WorkForever.Services.FactoryService;

namespace WorkForever.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FactoryController : ControllerBase
{
    private readonly IFactoryService _characterService;

    public FactoryController(IFactoryService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<List<GetFactoryDto>>>> GetAll()
    {
        return Ok(await _characterService.GetAllFactories());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
    {
        return Ok(await _characterService.GetFactoryById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<AddCharacterDto>>> AddFactory(AddFactoryDto newFactory)
    {
        return Ok(await _characterService.AddFactory(newFactory));
    }
    
}