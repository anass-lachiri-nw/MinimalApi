namespace MinimalApi_Carter.Exceptions;

public class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException(string? message)
        : base(message)
    {
    }
}
