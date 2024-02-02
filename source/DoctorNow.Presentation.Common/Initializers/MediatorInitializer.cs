using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorNow.Presentation.Common.Initializers;

public static class MediatorInitializer
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(
            config => config.RegisterServicesFromAssembly(assembly));

        return services;
    }
}