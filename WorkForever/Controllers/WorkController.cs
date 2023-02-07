using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkForever.Dtos.Work;
using WorkForever.Models;
using WorkForever.Services.WorkService;

namespace WorkForever.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class WorkController:ControllerBase
{
    IWorkService _workService;
    
    public WorkController(IWorkService workService)
    {
        _workService = workService;
    }
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<WorkResultDto>>> Work(WorkRequestDto workRequest)
    {
        return Ok(await _workService.CreateWork(workRequest));
    }
    
    
}