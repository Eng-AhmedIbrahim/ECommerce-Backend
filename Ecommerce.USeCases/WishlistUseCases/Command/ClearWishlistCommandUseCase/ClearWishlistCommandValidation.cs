namespace Ecommerce.UseCases.WishlistUseCases.Command.ClearWishlistCommandUseCase;

public class ClearWishlistCommandValidation : AbstractValidator<ClearWishlistCommand>
{
    public ClearWishlistCommandValidation()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .NotNull().WithMessage("UserId cannot be null.");
    }
}