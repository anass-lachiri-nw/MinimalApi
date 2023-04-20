namespace MinimalApi_FastEndpoints.Exceptions;

public class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException(string? message)
        : base(message)
    {
    }
}
