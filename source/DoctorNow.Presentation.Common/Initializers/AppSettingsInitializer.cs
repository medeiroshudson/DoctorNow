using DoctorNow.Domain.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DoctorNow.Presentation.Common.Initializers;

public static class AppSettingsInitializer
{
    public static void AddAppSettings(this WebApplicationBuilder applicationBuilder)
    {
        var env = applicationBuilder.Environment;
        var config = applicationBuilder.Configuration;

        applicationBuilder.Configuration
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

        applicationBuilder.Services
            .AddOptions<DatabaseOptions>()
            .Bind(config.GetSection(DatabaseOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}