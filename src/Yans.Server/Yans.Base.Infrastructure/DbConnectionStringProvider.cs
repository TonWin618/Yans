using Microsoft.Extensions.Configuration;

namespace Yans.Base.Infrastructure;

public static class DbConnectionStringProvider
{
    public static string? GetConnectionString<TDbContext>()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile($"config.json",  true)
            .AddJsonFile($"config.development.json", true)
            .Build();

        return configuration.GetConnectionString("database");
    }
}
