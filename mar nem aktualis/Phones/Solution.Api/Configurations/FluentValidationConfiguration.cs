namespace Solution.Api.Configurations;

public static class FluentValidationConfiguration
{
    public static WebApplicationBuilder ConfigureFluentValidation(this WebApplicationBuilder builder)
    {
        builder.Services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
        });

        builder.Services.AddFluentValidationClientsideAdapters();
        builder.Services.AddValidatorsFromAssembly(Solution.Validators.AssemblyReference.Assembly);

        return builder;
    }
}
