using DoctorNow.Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DoctorNow.Presentation.Common.HealthChecks;

public class DatabaseHealthCheck(AppDbContext dbContext) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await dbContext.Database.CanConnectAsync(cancellationToken);

            return HealthCheckResult.Healthy();
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(exception: ex);
        }
    }
}