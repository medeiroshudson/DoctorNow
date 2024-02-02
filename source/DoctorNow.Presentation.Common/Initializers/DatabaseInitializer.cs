using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DoctorNow.Infrastructure.Persistence.Contexts;

namespace DoctorNow.Presentation.Common.Initializers;

public static class DatabaseInitializer
{
    public static IServiceCollection InitializeDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DoctorNowDb");
        
        services.AddDbContext<AppDbContext>(
            opt => opt.UseNpgsql(connectionString, actions =>
            {
                actions.EnableRetryOnFailure(3);
                actions.CommandTimeout(30);
                actions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
            }));

        return services;
    }
}