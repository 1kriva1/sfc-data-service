using System.Reflection;

using AutoMapper;

using SFC.Data.Application.Common.Mappings.Interfaces;

namespace SFC.Data.Application.Common.Mappings.Base;
#pragma warning disable CA1012 // Abstract types should not have public constructors
public abstract class BaseMappingProfile : Profile
#pragma warning restore CA1012 // Abstract types should not have public constructors
{
    protected abstract Assembly Assembly { get; }

    public BaseMappingProfile()
    {
        Configure();

        ApplyMappingsFromAssembly(Assembly);
    }

    private void Configure()
    {
        AllowNullCollections = true;
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        string mappingMethodName = nameof(IMapFrom<object>.Mapping);

        static bool HasInterface(Type t) => t.IsGenericType &&
            (t.GetGenericTypeDefinition() == typeof(IMapFrom<>) || t.GetGenericTypeDefinition() == typeof(IMapFromReverse<>));

        List<Type> types = assembly.GetExportedTypes()
                                   .Where(t => t.GetInterfaces().Any(HasInterface) && !t.IsInterface)
                                   .ToList();

        Type[] argumentTypes = [typeof(Profile)];

        foreach (Type type in types)
        {
            object? instance = Activator.CreateInstance(type);

            MethodInfo? methodInfo = type.GetMethod(mappingMethodName);

            if (methodInfo != null)
            {
                methodInfo.Invoke(instance, [this]);
            }
            else
            {
                List<Type> interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                if (interfaces.Count > 0)
                {
                    foreach (Type @interface in interfaces)
                    {
                        MethodInfo? interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                        interfaceMethodInfo?.Invoke(instance, [this]);
                    }
                }
            }
        }
    }
}