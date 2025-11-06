namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.RefreshToken;

public record RefreshTokenCommand(
    string? Token
    ) : IRequest<LoginResponseDto> 
{}