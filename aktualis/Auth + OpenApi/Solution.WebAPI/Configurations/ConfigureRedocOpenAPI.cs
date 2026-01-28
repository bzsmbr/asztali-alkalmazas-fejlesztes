namespace Solution.WebAPI.Configurations;

public static class ConfigureRedocOpenAPI
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder UseReDocOpenAPI()
        {
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddOpenApi(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
                options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My Test App API",
                    Description = "An ASP.NET Core Web API for My Test App",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                });

                options.AddSecurityRequirement(document => new() { [new OpenApiSecuritySchemeReference("Bearer", document)] = [] });
            });

            return builder;
        }
    }

    extension(WebApplication app)
    {
        public IApplicationBuilder UseReDocOpenAPI()
        {
            app.MapOpenApi();

            app.UseSwagger(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
            });

            app.UseReDoc(options =>
            {
                options.RoutePrefix = "redoc";
                options.SpecUrl = "/openapi/v1.json";
                options.DocumentTitle = "My Test App API Documentation";
            }); ;

            return app;
        }
    }
}
