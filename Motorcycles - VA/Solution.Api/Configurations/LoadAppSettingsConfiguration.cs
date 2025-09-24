namespace Solution.Api.Configurations;

public static class LoadAppSettingsConfiguration
{
    public static WebApplicationBuilder LoadAppSettingsVariables(this WebApplicationBuilder builder)
    {
        var environment = builder.Configuration.GetValue<string>("Environment");

        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", true)
                             .AddJsonFile($"appsettings.{environment}.json", true)
                             .AddEnvironmentVariables();

        return builder;
    }
}
