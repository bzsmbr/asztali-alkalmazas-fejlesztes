
namespace Solution.Api.Configurations;

public static class DatabaseConfiguration
{
    public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseLazyLoadingProxies()
                   .UseSqlServer(connectionString, options =>
                   {
                       options.MigrationsAssembly(Validators.AssemblyReference.Assembly);
                       options.EnableRetryOnFailure();
                       options.CommandTimeout(300);
                   })
        //.LogTo(Console.WriteLine) //please let it here for debugging purposes
        );

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        return builder;
    }
}
