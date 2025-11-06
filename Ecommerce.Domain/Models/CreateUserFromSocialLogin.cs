namespace Ecommerce.Domain.Models;

public class CreateUserFromSocialLogin
{
    public string UserName { get; set; } = string.Empty;

    public string? ProfilePicture { get; set; }

    public string Email { get; set; } = string.Empty;

    public string LoginProviderSubject { get; set; } = string.Empty;
}