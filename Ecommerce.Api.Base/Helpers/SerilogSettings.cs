namespace Ecommerce.Api.Base.Helpers;

public static class SerilogSettings
{
    public static void AddSerilogSettings()
    {
        var loggerConfiguration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("serilog.json", optional: false, reloadOnChange: true)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(loggerConfiguration)
            .CreateLogger();
    }
}
