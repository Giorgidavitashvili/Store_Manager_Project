using Microsoft.Extensions.Configuration;

namespace StoreManager.Configuration;

public static class ConfigurationManager
{
    private readonly static IConfiguration _configuration;

    static ConfigurationManager()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        _configuration = builder.Build();

        ConnectionString = _configuration["ConnectionStrings:DefaultConnection"];
    }

    public static string? ConnectionString { get; }
}