using MinimalApi_FastEndpoints.Helpers.Interfaces;

namespace MinimalApi_FastEndpoints.Helpers.Implementations;

internal class Clock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}