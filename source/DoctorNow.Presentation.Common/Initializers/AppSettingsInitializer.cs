using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace DoctorNow.Presentation.Common.Initializers;

public static class AppSettingsInitializer
{
    public static void AddAppSettings(this WebApplicationBuilder applicationBuilder)
    {
        var env = applicationBuilder.Environment;

        applicationBuilder.Configuration
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
    }
}