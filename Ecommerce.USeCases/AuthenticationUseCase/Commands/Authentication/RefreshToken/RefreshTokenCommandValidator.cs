namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
     =>   RuleFor(r => r.Token).NotNull().NotEmpty();
}
