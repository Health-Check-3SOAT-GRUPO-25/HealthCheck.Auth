using HealthCheck.Auth.IOC.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Auth.IOC;

public static class DependencyInjectionConfiguration
{
    public static void Register
    (
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        ConfigureOptions.Register(services, configuration);
        ConfigureDatabase.Register(services, configuration);
        ConfigureHealthChecks.Register(services);
        ConfigureServices.Register(services);
        ConfigureSecurity.Register(services, configuration);
    }
}