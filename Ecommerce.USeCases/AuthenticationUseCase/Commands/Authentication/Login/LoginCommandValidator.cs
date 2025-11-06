namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(u=>u.Email).NotEmpty().NotNull();
        RuleFor(u=>u.Password).NotEmpty().NotNull();
    }
}