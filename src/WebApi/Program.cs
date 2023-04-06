using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();