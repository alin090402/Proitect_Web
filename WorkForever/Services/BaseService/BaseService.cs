using System.Security.Claims;
using AutoMapper;
using WorkForever.Models.Enums;
using WorkForever.Repositories.UnitOfWork;

namespace WorkForever.Services;

public class BaseService : IBaseService
{
    protected readonly IMapper Mapper;
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly IHttpContextAccessor HttpContextAccessor;

    public BaseService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        HttpContextAccessor = httpContextAccessor;
    }

    protected int GetUserId()
    {
        if (HttpContextAccessor.HttpContext != null)
            return int.Parse(HttpContextAccessor.HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier));
        else return -1;
    }

    protected UserRole GetUserRole()
    {
        var id = GetUserId();
        var user = UnitOfWork.UserRepository.FindById(id);
        if (user != null)
            return user.Role;
        return UserRole.None;
    }
    
    protected bool IsAdmin()
    {
        return GetUserRole() == UserRole.Admin;
    }
}