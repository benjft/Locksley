using BenJFT.Locksley.Common.Services.Interfaces;

namespace BenJFT.Locksley.Common.Helpers;

public static class ServiceExtensions {
    public static void RegisterService(this IServiceCollection services, ServiceLifetime lifetime, Type cls,
        Type? itf = null) {
        itf ??= cls;

        if (services.RegisterFactoryService(lifetime, cls, itf))
            return;

        _ = lifetime switch {
            ServiceLifetime.Singleton => services.AddSingleton(itf, cls),
            ServiceLifetime.Scoped => services.AddScoped(itf, cls),
            ServiceLifetime.Transient => services.AddTransient(itf, cls),
            _ => services.AddTransient(itf, cls)
        };
    }

    public static bool RegisterFactoryService(this IServiceCollection services, ServiceLifetime lifetime, Type cls,
        Type itf) {
        if (!typeof(IHasFactory<>).MakeGenericType(cls).IsAssignableFrom(cls))
            return false;

        var factoryInfo = cls.GetMethod("NewInstance");
        if (factoryInfo == null)
            return false;

        object Factory(IServiceProvider sp) {
            return factoryInfo.Invoke(null, new object?[] {sp})!;
        }

        _ = lifetime switch {
            ServiceLifetime.Singleton => services.AddSingleton(itf, Factory),
            ServiceLifetime.Scoped => services.AddScoped(itf, Factory),
            ServiceLifetime.Transient => services.AddTransient(itf, Factory),
            _ => services.AddTransient(itf, Factory)
        };

        return true;
    }
}