var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.LoadEnvironmentVariables()
       .ConfigureDatabase()
       .LoadSettings()
       .ConfigureDI()
       .UseSecurity()
       .UseIdentity()
       //.UseScalarOpenAPI()
       //.UseSwashbuckleOpenAPI()
       .UseReDocOpenAPI();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
app.UseSecurity();
app.MapControllers();
//app.UseScalarOpenAPI();
//app.UseSwashbuckleOpenAPI();
app.UseReDocOpenAPI();
app.Run();
