namespace Solution.WebAPI.Configurations;

public static class ExceptionHandlingConfiguration
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder AddGlobalErrorHandling()
        {
            builder.Services.AddProblemDetails(options =>
            {
                options.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                };
            });

            builder.Services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();

            return builder;
        }
    }

    extension(WebApplication app)
    {
        public WebApplication AddGlobalErrorHandling()
        {
            app.UseExceptionHandler();

            return app;
        }
    }
}
