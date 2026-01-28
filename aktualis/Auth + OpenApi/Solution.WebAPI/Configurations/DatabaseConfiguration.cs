namespace Solution.WebAPI.Configurations;

public static class DatabaseConfiguration
{
    extension(IHostApplicationBuilder builder)
    {
        public IHostApplicationBuilder ConfigureDatabase()
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies()
                       .UseSqlServer(connectionString, options =>
                       {
                           options.MigrationsAssembly(DomainAssemblyReference.Assembly);
                           options.EnableRetryOnFailure();
                           options.CommandTimeout(300);
                       })
            //.LogTo(Console.WriteLine) //please let it here for debugging purposes
            );

            return builder;
        }
    }
}
