var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.LoadEnviorementVariables()
       .ConfigureDI()
       .LoadSettings()
       .ConfigureDatabase()
       .UseIdentity()
       .UseSecurity()
       .AddGlobalErrorHandling()
       //.UseScalarOpenAPI()
       //UseSwashbuckleOpenAPI()
       .UseReDocOpenAPI();



var app = builder.Build();
app.AddGlobalErrorHandling();
app.UseHttpsRedirection();
app.UseRouting();
app.UseSecurity();
app.MapControllers();
//app.UseScalarOpenAPI();
//app.UseSwashbuckleOpenAPI();
app.UseReDocOpenAPI();

await app.RunAsync();
