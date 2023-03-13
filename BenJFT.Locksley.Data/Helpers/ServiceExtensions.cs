using BenJFT.Locksley.Data.Models;
using BenJFT.Locksley.Data.Providers;
using BenJFT.Locksley.Data.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BenJFT.Locksley.Data.Helpers;

public static class ServiceExtensions {
    public static IServiceCollection RegisterData(this IServiceCollection services) {
        services.AddTransient<IDataProvider<ScoreSheet>, ScoreSheetDataProvider>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string dataDirectory) {
        return services.AddDbContext<LocksleyDbContext>(options =>
            options.UseLazyLoadingProxies()
                .UseSqlite($"Filename={Path.Combine(dataDirectory, "LocksleyData.sqlite")}")
        );
    }
}