using Bills.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.LoadAppSettingsVariables()
       .ConfigureDI()
       .ConfigureDatabase();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
