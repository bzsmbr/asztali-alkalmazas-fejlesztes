namespace Solution.WebAPI.Configurations;

public static class ConfigureSwaggerOpenAPI
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder UseSwashbuckleOpenAPI()
        {
            builder.Services.AddOpenApi(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
            });

            builder.Services.AddEndpointsApiExplorer();

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
        public IApplicationBuilder UseSwashbuckleOpenAPI()
        {
            app.MapOpenApi();

            app.UseSwagger(options =>
            {
                options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}
