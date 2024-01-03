using System.Reflection;
using Locksley.Common.Attributes;
using Locksley.Common.Helpers;
using Locksley.Pages;
using Locksley.Services;
using Locksley.Services.Interfaces;
using Locksley.ViewModels;

namespace Locksley.Helpers;

public static partial class ServiceHelper {
    private static readonly string ServicesNamespace = typeof(PageFactory).Namespace!;
    private static readonly string ServiceInterfacesNamespace = typeof(IPageFactory).Namespace!;
    private static readonly string PagesNamespace = typeof(MainPage).Namespace!;
    private static readonly string ViewModelsNamespace = typeof(BaseViewModel).Namespace!;


    public static IServiceCollection RegisterServices(this IServiceCollection services) {
        foreach (var service in Assembly.GetCallingAssembly().GetTypes()
                     .Where(t => t.Namespace != null && 
                                 t.Namespace.StartsWith(ServicesNamespace))) {
            
            var serviceLifetime = service.GetCustomAttribute<ServiceLifetimeAttribute>()?.ServiceLifetime ??
                                  ServiceLifetime.Transient;
            foreach (var serviceInterface in service.GetInterfaces()
                         .Where(i => i.Namespace != null && 
                                     i.Namespace.StartsWith(ServiceInterfacesNamespace))) {
                services.AddService(serviceLifetime, serviceInterface, service);
            }
        }

        return services;
    }

    public static IServiceCollection RegisterViewAndPages(this IServiceCollection services) {
        var viewAndPageTypes = Assembly.GetCallingAssembly().GetTypes()
            .Where(t => t.Namespace != null
                        && t.Namespace.StartsWith(PagesNamespace)
                        && typeof(IView).IsAssignableFrom(t)
                        && t is {IsClass: true, IsAbstract: false});

        // Register all as Transient
        foreach (var type in viewAndPageTypes) {
            services.AddTransient(type);
        }

        return services;
    }

    public static IServiceCollection RegisterViewModels(this IServiceCollection services) {
        var viewAndPageTypes = Assembly.GetCallingAssembly().GetTypes()
            .Where(t => t.Namespace != null
                        && t.Namespace.StartsWith(ViewModelsNamespace)
                        && typeof(BaseViewModel).IsAssignableFrom(t)
                        && t is {IsClass: true, IsAbstract: false});

        // Register all as Transient
        foreach (var type in viewAndPageTypes) {
            services.AddTransient(type);
        }

        return services;
    }

    public static partial IServiceCollection ConfigureLogging(this IServiceCollection services);
}