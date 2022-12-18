using WorkForever.Helpers.Seeders;
using WorkForever.Repositories;
using WorkForever.Repositories.UnitOfWork;
using WorkForever.Services.AuthService;
using WorkForever.Services.CharacterService;

namespace WorkForever.Helpers.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICharacterRepository, CharacterRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICharacterService, CharacterService>();
        services.AddTransient<IAuthService, AuthService>();
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