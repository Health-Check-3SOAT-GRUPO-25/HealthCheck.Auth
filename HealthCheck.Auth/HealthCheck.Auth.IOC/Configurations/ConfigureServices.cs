using HealthCheck.Auth.Application.Services;
using HealthCheck.Auth.Domain.Interface.Repositories;
using HealthCheck.Auth.Domain.Interface.Services;
using HealthCheck.Auth.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Auth.IOC.Configurations;

public static class ConfigureServices
{
    public static void Register
    (
        IServiceCollection services
    )
    {
        #region Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddHttpContextAccessor();
        services.AddScoped<IAuthenticatedUser, AuthenticatedUser>();

        #endregion Services

        #region Repositories

        services.AddScoped<IUserRepository, UserRepository>();

        #endregion Repositories
    }
}