namespace MinimalApi_FastEndpoints.Helpers.Interfaces;

public interface IClock
{
    DateTime UtcNow { get; }
}
