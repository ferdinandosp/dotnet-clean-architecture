using Autofac;
using MyApp.Domain.Core.Repositories;
using MyApp.Infrastructure.Repositories;
using System.Reflection;

namespace MyApp.Infrastructure;
public class DefaultInfrastructureModule : Autofac.Module
{
    private readonly List<Assembly> _assemblies = new();

    public DefaultInfrastructureModule(Assembly callingAssembly = null)
    {
        var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));

        if (infrastructureAssembly != null)
        {
            _assemblies.Add(infrastructureAssembly);
        }

        if (callingAssembly != null)
        {
            _assemblies.Add(callingAssembly);
        }
    }

    protected override void Load(ContainerBuilder builder)
    {
        RegisterCommonDependencies(builder);
    }

    private static void RegisterCommonDependencies(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IAppRepository<>))
            .As(typeof(IAppReadRepository<>))
            .InstancePerLifetimeScope();
    }
}
