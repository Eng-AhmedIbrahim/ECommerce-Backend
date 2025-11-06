namespace Ecommerce.UseCases.WishlistUseCases.Command.RemoveItemFromWishlistCommandUseCase;

public class RemoveItemFromWishlistCommandValidations : AbstractValidator<RemoveItemFromWishlistCommand>
{
    public RemoveItemFromWishlistCommandValidations()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .NotNull().WithMessage("UserId cannot be null.");
        
        RuleFor(x => x.ProductId)
                   .GreaterThan(0).
                   WithMessage("ProductId must be greater than zero.");
    }
}