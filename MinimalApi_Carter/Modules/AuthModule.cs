using Carter;
using MinimalApi_Carter.Helpers.Interfaces;

namespace MinimalApi_Carter.Modules;

public class AuthModule : CarterModule
{
    public AuthModule()
        : base("/auth")
    {
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/login", (IJwtTokenGenerator jwtTokenGenerator) => jwtTokenGenerator.GenerateToken()).AllowAnonymous();
    }
}