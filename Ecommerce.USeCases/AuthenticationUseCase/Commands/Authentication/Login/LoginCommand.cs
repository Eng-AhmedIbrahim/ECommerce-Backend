namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.Login;

public record LoginCommand(
    string? Email,
    string? Password
    ) :IRequest<LoginResponseDto>
{ }