using System.Reflection;
using Locksley.Common.Attributes;
using Locksley.Common.Exceptions;
using Locksley.Pages;
using Locksley.Services;
using Locksley.Services.Interfaces;

namespace Locksley.Helpers;

public static class ServiceHelper {
    private static readonly string ServicesNamespace = typeof(PageFactory).Namespace;
    private static readonly string ServiceInterfacesNamespace = typeof(IPageFactory).Namespace;
    private static readonly string PagesNamespace = typeof(MainPage).Namespace;


    public static IServiceCollection RegisterServices(this IServiceCollection services) {
        foreach (var service in Assembly.GetCallingAssembly().GetTypes()
                     .Where(t => t.Namespace == ServicesNamespace)) {
            var serviceLifetime = service.GetCustomAttribute<ServiceLifetimeAttribute>()?.ServiceLifetime ??
                                  ServiceLifetime.Transient;
            foreach (var serviceInterface in service.GetInterfaces()
                         .Where(i => i.Namespace == ServiceInterfacesNamespace)) {
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
            .Where(t => t.Namespace == PagesNamespace
                        && typeof(IView).IsAssignableFrom(t));

        // Register all as Transient
        foreach (var type in viewAndPageTypes) {
            services.AddTransient(type);
        }

        return services;
    }
}