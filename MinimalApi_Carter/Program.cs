using Carter;
using MinimalApi_Carter.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddCarter();

var app = builder.Build();

// app.MapGet("/forbidden", () => Results.Forbid()).AllowAnonymous();

app.Setup();
app.MapCarter();
await app.RunAsync();