var builder = WebApplication.CreateBuilder(args);

builder.LoadAppSettingsVariables()
       .ConfigureDI()
       .ConfigureDatabase()
       .ConfigureFluentValidation();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
