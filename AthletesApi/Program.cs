using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMemoryCache();

builder.Services.AddApplication();
#warning pass connection string into a constant in common lib
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString);


builder.Services.AddSwaggerDocument(settings =>
{
    settings.Title = "Athletes.Api";
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();
