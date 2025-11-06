namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, LoginResponseDto>
{
    private readonly IAuthenticationService _authService;

    public RefreshTokenCommandHandler(IAuthenticationService authService)
    => _authService = authService;
    public async Task<LoginResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var response = await _authService.RefreshTokenAsync(request!.Token ?? string.Empty);
        return response!;
    }
}
