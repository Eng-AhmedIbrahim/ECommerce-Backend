namespace Ecommerce.UseCases.WishlistUseCases.Query.GetWishlistQueryUseCase;

public class GetWishlistQueryValidations : AbstractValidator<GetWishlistQuery>
{
    public GetWishlistQueryValidations()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .NotNull().WithMessage("UserId cannot be null.");
    }
}