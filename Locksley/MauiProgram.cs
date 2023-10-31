using Locksley.Helpers;
using Locksley.Services;
using Locksley.Services.Implementation;
using Microsoft.Extensions.Logging;

namespace Locksley;

public static class MauiProgram {
    public static MauiApp CreateMauiApp() {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services
            .RegisterServices()
            .RegisterViewAndPages();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}