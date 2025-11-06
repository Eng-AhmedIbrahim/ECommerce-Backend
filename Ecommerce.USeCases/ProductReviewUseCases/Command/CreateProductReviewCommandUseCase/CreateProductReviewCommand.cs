namespace Ecommerce.UseCases.ProductReviewUseCases.Command.CreateProductReviewCommandUseCase;

public record CreateProductReviewCommand
    (ProductReviewDto productReviewDto)
    : IRequest<ProductReviewsToReturnDto>;