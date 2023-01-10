using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkForever.Dtos.Factory;
using WorkForever.Models;
using WorkForever.Services.FactoryService;

namespace WorkForever.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FactoryController : ControllerBase
{
    private readonly IFactoryService _factoryService;

    public FactoryController(IFactoryService factoryService)
    {
        _factoryService = factoryService;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<List<GetFactoryDto>>>> GetAll()
    {
        return Ok(await _factoryService.GetAllFactories());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetFactoryDto>>> GetSingle(int id)
    {
        return Ok(await _factoryService.GetFactoryById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetFactoryDto>>> AddFactory(AddFactoryDto newFactory)
    {
        return Ok(await _factoryService.AddFactory(newFactory));
    }
    
}