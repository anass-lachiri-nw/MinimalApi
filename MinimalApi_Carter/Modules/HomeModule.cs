using Carter;

namespace MinimalApi_Carter.Modules;

public class HomeModule : CarterModule
{
    public HomeModule()
        : base("/home")
    {
        this.RequireAuthorization("Admin");
    }
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello World!");
    }
}