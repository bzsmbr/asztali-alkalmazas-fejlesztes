var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.UseSecurity();
builder.UseScalarOpenAPI();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseScalarOpenAPI();
}

app.UseHttpsRedirection();
app.UseSecurity();
app.MapControllers();
app.Run();
