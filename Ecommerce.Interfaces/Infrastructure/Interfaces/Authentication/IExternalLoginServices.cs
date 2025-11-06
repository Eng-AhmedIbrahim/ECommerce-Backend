namespace Ecommerce.Interfaces.Infrastructure.Interfaces.Authentication;

public interface IExternalLoginServices
{
    public Task<LoginResponseDto?> SignInWithGoogle(GoogleSignInVM model,CancellationToken cancellationToken);
}