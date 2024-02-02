using Autofac;
using DoctorNow.Application.Abstractions;
using ApplicationLayer = DoctorNow.Application.Application;

namespace DoctorNow.Infrastructure.CrossCutting.IoC;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = ApplicationLayer.GetExecutingAssembly();
        
        builder.RegisterAssemblyTypes(assembly)
            .AsClosedTypesOf(typeof(ICommandHandler<,>))
            .AsImplementedInterfaces();
        
        builder.RegisterAssemblyTypes(assembly)
            .AsClosedTypesOf(typeof(IQueryHandler<,>))
            .AsImplementedInterfaces();
        
        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();
    }
}