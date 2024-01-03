using System.Reflection;
using Locksley.Common.Attributes;
using Locksley.Common.Helpers;
using Locksley.Data.Repositories;

namespace Locksley.Data.Helpers;

public static class ServiceHelper {
    private static readonly string RepositoryNamespace = typeof(DummyScoreSheetRepository).Namespace!;
        public static IServiceCollection RegisterRepositories(this IServiceCollection services) {
        foreach (var service in typeof(DummyScoreSheetRepository).Assembly.GetTypes()
                     .Where(t => t.Namespace != null && 
                                 t.Namespace.StartsWith(RepositoryNamespace))) {
            
            var serviceLifetime = service.GetCustomAttribute<ServiceLifetimeAttribute>()?.ServiceLifetime ??
                                  ServiceLifetime.Transient;
            foreach (var serviceInterface in service.GetInterfaces()
                         .Where(i => i.Namespace != null 
                                     && i.Namespace.StartsWith(RepositoryNamespace))) {
                services.AddService(serviceLifetime, serviceInterface, service);
            }
        }

        return services;
    }
}