using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DoctorNow.Presentation.Common.Initializers;

public static class SwaggerInitializer
{
    public static IServiceCollection ConfigureSwaggerExplorer(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo { Title = "DoctorNow", Version = "v1" });
            
            config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
            });
        });
        
        services.AddEndpointsApiExplorer();

        return services;
    }
}