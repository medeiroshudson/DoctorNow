using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DoctorNow.Infrastructure.Persistence.Contexts;

namespace DoctorNow.Presentation.Common.Initializers;

public static class DatabaseInitializer
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>();

        return services;
    }
}