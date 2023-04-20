using FastEndpoints;

namespace MinimalApi_FastEndpoints.Endpoints;

public class HelloWorldEndpoint : EndpointWithoutRequest<string>
{
    public override void Configure()
    {
        Get("/home");
        Roles("admin");
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync("Hello world", cancellation: ct);
    }

}