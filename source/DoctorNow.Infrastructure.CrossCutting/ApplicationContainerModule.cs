using Autofac;
using DoctorNow.Application;
using DoctorNow.Infrastructure.CrossCutting.IoC;

namespace DoctorNow.Infrastructure.CrossCutting;

public class ApplicationContainerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<ApplicationModule>();
        builder.RegisterModule<InfrastructureModule>();
    }
}