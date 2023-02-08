using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkForever.Dtos.Item;
using WorkForever.Models;
using WorkForever.Models.Base;
using WorkForever.Services.ItemService;

namespace WorkForever.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ItemController: ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> GetAllItems()
    {
        return Ok(await _itemService.GetAllItems());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetItemDto>>> GetItemById(int id)
    {
        return Ok(await _itemService.GetItemById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> AddItem(AddItemDto item)
    {
        return Ok(await _itemService.AddItem(item));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<List<GetItemDto>>>> DeleteItem(int id)
    {
        ServiceResponse<List<GetItemDto>> response = await _itemService.DeleteItem(id);
        if (response.Data == null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}