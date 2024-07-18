using HealthCheck.Auth.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HealthCheck.Auth.IOC.Configurations;

public static class ConfigureDatabase
{
    public static void Register
       (
           IServiceCollection services,
           IConfiguration configuration
       )
    {
        services
            .AddEntityFrameworkSqlServer()
            .AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                      sqlServerOptionsAction: sqlOptions =>
                      {
                          sqlOptions.EnableRetryOnFailure(
                              maxRetryCount: 3,
                              maxRetryDelay: TimeSpan.FromSeconds(10),
                              errorNumbersToAdd: null);
                      });
            });
    }
}
