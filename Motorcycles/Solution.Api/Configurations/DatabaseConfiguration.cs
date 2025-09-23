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
                       options.MigrationsAssembly(Database.AssemblyReference.Assembly);
                       options.EnableRetryOnFailure();
                       options.CommandTimeout(300);
                   })
            );
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();


    return builder;
    }
}
