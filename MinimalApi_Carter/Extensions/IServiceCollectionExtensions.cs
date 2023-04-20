using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using MinimalApi_Carter.Auth;
using MinimalApi_Carter.Exceptions;
using MinimalApi_Carter.Helpers.Implementations;
using MinimalApi_Carter.Helpers.Interfaces;

namespace MinimalApi_Carter.Extensions;

internal static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add services to the container.
        services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => options.SupportNonNullableReferenceTypes());
        
        services.AddSingleton<IClock, Clock>();
        
        services.AddOptions<JwtSettings>()
            .Bind(configuration.GetSection(JwtSettings.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        IConfigurationSection jwtSettingsSection = configuration.GetSection(JwtSettings.SectionName);
        JwtSettings jwtSettings = jwtSettingsSection.Get<JwtSettings>()
                                  ?? throw new InvalidConfigurationException(JwtSettings.SectionName + " missing.");
        services.AddAuthentication()
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });
        
        services.AddAuthorization(options =>
        {
            AuthorizationPolicy alwaysDenyPolicy = new AuthorizationPolicyBuilder()
                .RequireAssertion(_ => false)
                .Build();
            options.DefaultPolicy = alwaysDenyPolicy;
            options.FallbackPolicy = alwaysDenyPolicy;
            options.AddPolicy("Admin", policy => policy
                .RequireAuthenticatedUser()
                .RequireRole("admin"));
        });

        return services;
    }
}
