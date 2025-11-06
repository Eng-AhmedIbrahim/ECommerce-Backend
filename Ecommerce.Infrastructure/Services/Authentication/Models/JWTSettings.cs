namespace Ecommerce.Infrastructure.Services.Authentication.Models;

public class JWTSettings
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public double DurationInDays { get; set; } 
    public double DurationInHours { get; set; }
    public double DurationInMinutes { get; set; }
    public double RefreshTokenDurationInDays { get; set; }
}