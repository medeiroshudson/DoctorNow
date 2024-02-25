using Autofac;
using DoctorNow.Application.Abstractions.Security;
using DoctorNow.Domain.SharedKernel.Interfaces;
using DoctorNow.Infrastructure.Persistence.Contexts;
using DoctorNow.Infrastructure.Persistence.Repositories;
using DoctorNow.Infrastructure.Security;
using InfrastructureLayer = DoctorNow.Infrastructure.Infrastructure;

namespace DoctorNow.Infrastructure.CrossCutting.IoC;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = InfrastructureLayer.Assembly;
        
        builder.RegisterType<AppDbContext>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        
        builder.RegisterType<PasswordHasher>().As<IPasswordHasher>().InstancePerLifetimeScope();
        builder.RegisterType<JwtTokenProvider>().As<IJwtTokenProvider>().InstancePerLifetimeScope();
        
        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();
    }
}