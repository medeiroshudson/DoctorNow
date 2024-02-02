using Autofac;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Infrastructure.Persistence.Contexts;
using DoctorNow.Infrastructure.Persistence.Repositories;
using InfrastructureLayer = DoctorNow.Infrastructure.Infrastructure;

namespace DoctorNow.Infrastructure.CrossCutting.IoC;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = InfrastructureLayer.GetExecutingAssembly();
        
        builder.RegisterType<AppDbContext>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();
    }
}