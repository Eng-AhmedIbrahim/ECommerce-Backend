namespace Ecommerce.Interfaces.Infrastructure.Interfaces.Authentication;

public interface IAccountServices
{
    Task<LoginResponseDto?> RegisterAsync(SignUpDto dto);
    Task<LoginResponseDto?> LoginAsync(LoginDto dto);
    Task<bool> LogoutAsync();
}