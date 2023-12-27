using Locksley.Common.Exceptions;

namespace Locksley.Common.Helpers;

public static class ServiceHelper {
    

    public static void AddService(this IServiceCollection services, ServiceLifetime lifetime, Type serviceInterface, Type service) {
        switch (lifetime) {
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