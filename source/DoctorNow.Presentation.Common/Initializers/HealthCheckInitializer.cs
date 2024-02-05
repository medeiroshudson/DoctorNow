using System.Reflection;
using DoctorNow.Presentation.Common.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorNow.Presentation.Common.Initializers;

public static class HealthCheckInitializer
{
    public static IServiceCollection ConfigureHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<DatabaseHealthCheck>("database");

        return services;
    }
}