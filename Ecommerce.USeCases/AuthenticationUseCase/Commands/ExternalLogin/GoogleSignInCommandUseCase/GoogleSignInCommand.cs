namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.ExternalLogin.GoogleSignInCommandUseCase;

public record GoogleSignInCommand
    (
    GoogleSignInVM GoogleSignInVM
    ) : IRequest<LoginResponseDto?>
{ }