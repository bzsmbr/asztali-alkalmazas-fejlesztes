namespace Microsoft.AspNetCore.Builder;

//https://guides.scalar.com/scalar/scalar-api-references/integrations/net-aspnet-core/integration

public static class ConfigureOpenAPI
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder UseScalarOpenAPI()
        {
            builder.Services.AddOpenApi(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
                options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
            });
            
            builder.Services.AddEndpointsApiExplorer();

            return builder;
        }
    }

    extension(WebApplication app)
    {
        public IApplicationBuilder UseScalarOpenAPI()
        {
            app.MapOpenApi();

            app.MapScalarApiReference(options =>
            {
                options.WithTitle("WeatherForecast API Documentation")
                       .WithTheme(ScalarTheme.Default)
                       .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
                       .WithClassicLayout()
                       .ForceDarkMode()
                       .HideSearch()
                       .ShowOperationId()
                       .ExpandAllTags()
                       .SortTagsAlphabetically()
                       .SortOperationsByMethod();
            });

            return app;
        }
    }
}
