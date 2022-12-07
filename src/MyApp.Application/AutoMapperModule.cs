using Autofac;
using AutoMapper;
using System.Reflection;

namespace MyApp.Application;
public class AutoMapperModule : Autofac.Module
{
    private readonly List<Assembly> assembliesToScan;

    public AutoMapperModule(List<Assembly> assembliesToScan)
    {
        this.assembliesToScan = assembliesToScan;

        var assemblies = Assembly.GetAssembly(typeof(DefaultApplicationModule));

        this.assembliesToScan.Add(assemblies!);
    }

    public AutoMapperModule(params Assembly[] assembliesToScan) : this(assembliesToScan.ToList()) { }

    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        var allTypes = assembliesToScan
                      .Where(a => !a.IsDynamic && a.GetName().Name != nameof(AutoMapper))
                      .Distinct() // avoid AutoMapper.DuplicateTypeMapConfigurationException
                      .SelectMany(a => a.DefinedTypes)
                      .ToArray();

        var openTypes = new[] {
                            typeof(IValueResolver<,,>),
                            typeof(IMemberValueResolver<,,,>),
                            typeof(ITypeConverter<,>),
                            typeof(IValueConverter<,>),
                            typeof(IMappingAction<,>)
            };

        foreach (var type in openTypes.SelectMany(openType =>
         allTypes.Where(t => t.IsClass && !t.IsAbstract && ImplementsGenericInterface(t.AsType(), openType))))
        {
            builder.RegisterType(type.AsType()).InstancePerDependency();
        }

        builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(assembliesToScan.AsEnumerable());
        })).SingleInstance();

        builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve))
            .InstancePerDependency();
    }

    private static bool ImplementsGenericInterface(Type type, Type interfaceType)
              => IsGenericType(type, interfaceType) || type.GetTypeInfo().ImplementedInterfaces.Any(@interface => IsGenericType(@interface, interfaceType));

    private static bool IsGenericType(Type type, Type genericType)
              => type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericType;
}

