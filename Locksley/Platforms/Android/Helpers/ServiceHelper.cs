#if ANDROID
using Microsoft.Extensions.Logging;
using Locksley.Services;

namespace Locksley.Helpers;

public static partial class ServiceHelper {

    public static partial IServiceCollection ConfigureLogging(this IServiceCollection services) {
        services.AddLogging(configure => {
            const LogLevel logLevel = FlagHelper.IsDebug ? LogLevel.Debug : LogLevel.Information;
                
            configure.AddProvider(new AndroidLoggingProvider())
                .AddFilter((_, l) => l >= logLevel);
        });
        return services;
    }
}
#endif