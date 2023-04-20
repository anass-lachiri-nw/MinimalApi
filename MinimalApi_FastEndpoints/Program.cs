using FastEndpoints;
using MinimalApi_FastEndpoints.Extensions;
using MinimalApi_FastEndpoints.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddFastEndpoints();

var app = builder.Build();

app.MapGet("/forbidden", () => Results.Forbid()).AllowAnonymous();

app.Setup();
app.UseFastEndpoints();
await app.RunAsync();