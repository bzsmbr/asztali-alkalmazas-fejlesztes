var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.LoadEnvironmentVariables()
       .ConfigureDatabase()
       .LoadSettings()
       .ConfigureDI()
       .UseSecurity()
       .UseIdentity();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
app.UseSecurity();
app.MapControllers();


app.Run();
