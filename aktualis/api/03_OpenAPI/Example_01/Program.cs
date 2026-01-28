var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.UseSwashbuckleOpenAPI();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwashbuckleOpenAPI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
