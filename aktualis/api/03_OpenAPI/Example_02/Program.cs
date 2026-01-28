var builder = WebApplication.CreateBuilder(args);

builder.UseReDocOpenAPI();

builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseReDocOpenAPI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
