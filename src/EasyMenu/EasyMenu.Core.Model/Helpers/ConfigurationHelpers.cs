using Microsoft.Extensions.Configuration;

namespace EasyMenu.Core.Model.Helpers;

public static class ConfigurationHelpers
{
    private static IConfiguration GetConfiguration()
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{environment}.json", true);

        return configuration.Build();
    }
    public static string GetConnectionString(string sectionName)
    {
        var defaultConnectionConfig = GetConfiguration().GetSection(sectionName);
        var connectionString = defaultConnectionConfig.GetValue<string>("ConnectionString");
        if (!string.IsNullOrWhiteSpace(connectionString)) return connectionString;
        var defaultConnectionString = "server=" + defaultConnectionConfig.GetValue<string>("Server") + ";";
        defaultConnectionString += "uid=" + defaultConnectionConfig.GetValue<string>("Userid") + ";";
        defaultConnectionString += "pwd=" + defaultConnectionConfig.GetValue<string>("PasswordDB") + ";";
        defaultConnectionString += "database=" + defaultConnectionConfig.GetValue<string>("Database") + ";";
        return defaultConnectionString;
    }
}