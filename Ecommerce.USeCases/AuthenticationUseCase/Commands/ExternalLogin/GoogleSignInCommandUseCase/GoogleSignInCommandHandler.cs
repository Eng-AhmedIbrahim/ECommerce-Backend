namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.ExternalLogin.GoogleSignInCommandUseCase;

public class GoogleSignInCommandHandler : IRequestHandler<GoogleSignInCommand, LoginResponseDto?>
{
    private readonly IExternalLoginServices _externalLoginServices;

    public GoogleSignInCommandHandler(IExternalLoginServices externalLoginServices)
    {
        _externalLoginServices = externalLoginServices;
    }
    public async Task<LoginResponseDto?> Handle(GoogleSignInCommand request, CancellationToken cancellationToken)
        => await _externalLoginServices.SignInWithGoogle(request.GoogleSignInVM, cancellationToken);
}