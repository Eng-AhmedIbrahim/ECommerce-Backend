namespace Ecommerce.Interfaces.Infrastructure.Models.Authentication;

public class LoginResponseDto
{
    public string UserId { get; set; } = string.Empty;
    public string? Message { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime TokenExpiresOn { get; set; }
    [JsonIgnore] public string RefreshToken { get; set; } = string.Empty;
    [JsonIgnore]  public DateTime RefreshTokenExpiresOn { get; set; }
    public bool IsAuthenticated { get; set; }
    public List<string>? Roles { get; set; }
}