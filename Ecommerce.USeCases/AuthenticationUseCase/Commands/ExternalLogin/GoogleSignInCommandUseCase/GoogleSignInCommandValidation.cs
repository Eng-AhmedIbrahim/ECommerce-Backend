namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.ExternalLogin.GoogleSignInCommandUseCase;

public class GoogleSignInCommandValidation : AbstractValidator<GoogleSignInCommand>
{
    public GoogleSignInCommandValidation()
    {
        RuleFor(x => x.GoogleSignInVM.ClientId)
            .NotNull().WithMessage("ClientId cannot be null");
        RuleFor(x => x.GoogleSignInVM.IdToken)
            .NotNull().WithMessage("IdToken cannot be null");
    }
}