using System.Reflection;
using BenJFT.Locksley.App.ViewModels;
using BenJFT.Locksley.Common.Helpers;
using BenJFT.Locksley.Common.Services.Attributes;
using Microsoft.Extensions.Logging;
#if ANDROID
using BenJFT.Locksley.Platforms.Android.Services;
#endif

namespace BenJFT.Locksley.App.Helpers;

public static class ServiceExtensions {
    public static IServiceCollection AddViews(this IServiceCollection services) {
        var viewTypes = Assembly.GetCallingAssembly().GetSubClassesOf<Page>();

        foreach (var viewType in viewTypes) services.AddTransient(viewType);

        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services) {
        var viewModelTypes = Assembly.GetCallingAssembly().GetSubClassesOf<BaseViewModel>();

        foreach (var viewModelType in viewModelTypes)
            services.RegisterService(ServiceLifetime.Transient, viewModelType);

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services) {
        var classes = Assembly.GetCallingAssembly()
            .GetDecoratedTypes<ServiceLifetimeAttribute>()
            .Where(t => t is {IsInterface: false, IsAbstract: false});

        var clsInterfaces = classes.ToDictionary(
            c => c,
            c => c.BaseTypes()
                .Where(i => i.GetCustomAttribute<ServiceLifetimeAttribute>() != null)
                .Where(t => t.IsInterface || t.IsAbstract)
        );

        foreach (var (cls, interfaces) in clsInterfaces) {
            var itfArr = interfaces.ToArray();

            var serviceLifetime =
                cls.GetCustomAttribute<ServiceLifetimeAttribute>()?.Lifetime ??
                itfArr.Select(j => j.GetCustomAttribute<ServiceLifetimeAttribute>()).Min(lta => lta?.Lifetime) ??
                ServiceLifetime.Transient;

            Func<IServiceProvider, object>? clsFactory = null;
            if (itfArr.Length > 1 || cls.GetCustomAttribute<ServiceLifetimeAttribute>() != null) {
                services.RegisterService(serviceLifetime, cls);
                clsFactory = x => x.GetRequiredService(cls);
            }

            foreach (var itf in itfArr)
                if (clsFactory != null)
                    services.AddTransient(itf, clsFactory);
                else
                    services.RegisterService(serviceLifetime, cls, itf);
        }

        return services;
    }

    public static IServiceCollection AddOtherServices(this IServiceCollection services) {
#if ANDROID
        services.AddLogging(configure => {
#if DEBUG
            const LogLevel logLevel = LogLevel.Debug;
#else
            const LogLevel logLevel = LogLevel.Information;
#endif
            configure.AddProvider(new AndroidLoggingProvider())
                .AddFilter((_, l) => l >= logLevel);
        });
#else
        services.AddLogging(configure => {
            configure.AddDebug();
            configure.AddConsole();
        });
#endif
        return services;
    }
}