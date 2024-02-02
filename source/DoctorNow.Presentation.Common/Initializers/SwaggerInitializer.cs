using Microsoft.Extensions.DependencyInjection;

namespace DoctorNow.Presentation.Common.Initializers;

public static class SwaggerInitializer
{
    public static IServiceCollection AddSwaggerExplorer(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();

        return services;
    }
}