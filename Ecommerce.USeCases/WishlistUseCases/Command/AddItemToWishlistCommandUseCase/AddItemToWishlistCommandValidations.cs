namespace Ecommerce.UseCases.WishlistUseCases.Command.AddItemToWishlistCommandUseCase;

public class AddItemToWishlistCommandValidations :AbstractValidator<AddItemToWishlistCommand>
{
    public AddItemToWishlistCommandValidations()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .NotNull().WithMessage("UserId cannot be null.");

         RuleFor(x => x.ProductId)
            .GreaterThan(0).
            WithMessage("ProductId must be greater than zero.");
    }
}