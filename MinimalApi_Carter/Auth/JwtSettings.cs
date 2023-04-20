using System.ComponentModel.DataAnnotations;

namespace MinimalApi_Carter.Auth;

public class JwtSettings
{
    public static string SectionName { get; } = "JwtSettings";

    [Required]
    public required string Secret { get; init; }

    [Required]
    [Range(1, int.MaxValue)]
    public required int ExpiryMinutes { get; init; }

    [Required]
    public required string Issuer { get; init; }

    [Required]
    public required string Audience { get; init; }
}