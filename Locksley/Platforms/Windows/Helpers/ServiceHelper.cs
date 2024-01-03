#if WINDOWS
using Microsoft.Extensions.Logging;

namespace Locksley.Helpers;

public static partial class ServiceHelper {
    public static partial IServiceCollection ConfigureLogging(this IServiceCollection services) {
        services.AddLogging(configure => {
            configure.AddDebug();
            configure.AddConsole();
        });
        return services;
    }
}
#endif