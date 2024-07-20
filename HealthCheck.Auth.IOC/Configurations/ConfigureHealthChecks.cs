using HealthCheck.Auth.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCheck.Auth.IOC.Configurations;

public static class ConfigureHealthChecks
{
    public static void Register
    (
        IServiceCollection services
    )
    {
        services
            .AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();
    }
}
