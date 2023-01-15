using WorkForever.Helpers.Seeders;
using WorkForever.Repositories;
using WorkForever.Repositories.UnitOfWork;
using WorkForever.Services.AuthService;
using WorkForever.Services.FactoryService;
using WorkForever.Services.UserService;

namespace WorkForever.Helpers.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IFactoryRepository, FactoryRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IFactoryService, FactoryService>();
        return services;
    }

    public static IServiceCollection AddSeeders(this IServiceCollection services)
    {
        services.AddTransient<CharacterSeeder>();
        return services;
    }

    public static IServiceCollection AddUtils(this IServiceCollection services)
    {
        return services;
    }
}