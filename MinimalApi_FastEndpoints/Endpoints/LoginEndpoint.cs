using FastEndpoints;
using MinimalApi_FastEndpoints.DTOs.Auth;
using MinimalApi_FastEndpoints.Helpers.Interfaces;

namespace MinimalApi_FastEndpoints.Endpoints;

public class LoginEndpoint : EndpointWithoutRequest<LoginResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginEndpoint(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public override void Configure()
    {
        Get("/auth/login");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = new LoginResponse(_jwtTokenGenerator.GenerateToken());
        await SendAsync(response, cancellation: ct);
    }

}