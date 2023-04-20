using MinimalApi_Carter.Helpers.Interfaces;

namespace MinimalApi_Carter.Helpers.Implementations;

internal class Clock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}