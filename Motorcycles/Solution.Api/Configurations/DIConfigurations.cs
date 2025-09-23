namespace Solution.Api.Configurations;

public static class DIConfigurations
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();
        builder.Services.AddTransient<IValidatorInterceptor, FluentValidationInterceptor>();

        return builder;
    }
}
