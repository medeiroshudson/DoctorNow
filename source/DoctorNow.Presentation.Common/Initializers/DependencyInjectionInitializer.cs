using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using DoctorNow.Infrastructure.CrossCutting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;

namespace DoctorNow.Presentation.Common.Initializers;

public static class DependencyInjectionInitializer
{
    private static void Initialize(this ContainerBuilder builder)
    {
        builder.RegisterModule<ApplicationContainerModule>();
    }
    
    public static void ConfigureAutofacContainer(this WebApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.Initialize());
    }

    public static void ConfigureAutofacContainer(this MauiAppBuilder builder)
    { 
        builder.ConfigureContainer(new AutofacServiceProviderFactory(), container => container.Initialize());
    }
}