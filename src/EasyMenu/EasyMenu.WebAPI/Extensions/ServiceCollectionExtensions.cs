using Microsoft.EntityFrameworkCore;

namespace EasyMenu.WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IApplicationBuilder MigrateDatabaseUponAppStart<T>(this IApplicationBuilder app,
        string sectionName, ILogger logger) where T : DbContext
    {
        var configuration = app.ApplicationServices.GetService<IConfiguration>()?.GetSection(sectionName);
        if (!configuration?.GetValue<bool>("AutomaticMigrations") ?? true) return app;

        logger.LogTrace("MigrateDatabaseUponAppStart");

        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
        {
            if (serviceScope != null)
            {
                var migrationContext = serviceScope.ServiceProvider.GetRequiredService<T>();
                var applicationDb = migrationContext.Database;
                // applicationDb.SetCommandTimeout(TimeSpan.FromMinutes(5));
                applicationDb.Migrate();
            }
        }

        logger.LogTrace("MigrateDatabaseUponAppStart succeeded");

        return app;
    }
}