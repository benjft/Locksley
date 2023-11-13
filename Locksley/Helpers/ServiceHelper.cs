using System.Reflection;
using Locksley.Common.Attributes;
using Locksley.Common.Exceptions;

namespace Locksley.Helpers;

public static class ServiceHelper {
    public static IServiceCollection RegisterServices(this IServiceCollection services) {
        foreach (var service in Assembly.GetCallingAssembly().GetTypes()
                     .Where(t => t.Namespace == "Locksley.Services.Implementation")) {
            var serviceLifetime = service.GetCustomAttribute<ServiceLifetimeAttribute>()?.ServiceLifetime ??
                                  ServiceLifetime.Transient;
            foreach (var serviceInterface in service.GetInterfaces()
                         .Where(i => i.Namespace == "Locksley.Services")) {
                switch (serviceLifetime) {
                    case ServiceLifetime.Singleton:
                        services.AddSingleton(serviceInterface, service);
                        break;
                    case ServiceLifetime.Scoped:
                        services.AddScoped(serviceInterface, service);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(serviceInterface, service);
                        break;
                    default:
                        throw new ServiceLifetimeNotFoundException(
                            $"Invalid service lifetime for service: {service.Name}");
                }
            }
        }

        return services;
    }

    public static IServiceCollection RegisterViewAndPages(this IServiceCollection services) {
        var viewAndPageTypes = Assembly.GetCallingAssembly().GetTypes()
            .Where(t => t.Namespace is "Locksley.Content.Views" or "Locksley.Content.Pages"
                        && typeof(IView).IsAssignableFrom(t));

        // Register all as Transient
        foreach (var type in viewAndPageTypes) {
            services.AddTransient(type);
        }

        return services;
    }
}