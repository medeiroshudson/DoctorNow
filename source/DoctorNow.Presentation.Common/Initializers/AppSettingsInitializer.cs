using DoctorNow.Domain.Options;
using DoctorNow.Presentation.Common.Initializers.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorNow.Presentation.Common.Initializers;

public static class AppSettingsInitializer
{
    public static void ConfigureAppSettings(this WebApplicationBuilder builder)
    {
        var env = builder.Environment;
        var config = builder.Configuration;

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        builder.Services
            .AddOptions<DatabaseOptions>()
            .BindConfiguration(DatabaseOptions.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services
            .AddOptions<JwtOptions>()
            .BindConfiguration(JwtOptions.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
    }
}