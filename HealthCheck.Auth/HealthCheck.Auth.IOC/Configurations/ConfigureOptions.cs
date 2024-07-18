using HealthCheck.Auth.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Auth.IOC.Configurations;

public static class ConfigureOptions
{
    public static void Register
    (
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<JwtConfiguration>
        (
            options => configuration.GetSection("Jwt").Bind(options)
        );
    }
}
