namespace Ecommerce.UseCases.ProductReviewUseCases.Command.CreateProductReviewCommandUseCase;

public class CreateProductReviewCommandHandler : IRequestHandler<CreateProductReviewCommand, 
    ProductReviewsToReturnDto?>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateProductReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ProductReviewsToReturnDto?> Handle(CreateProductReviewCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var productReview = _mapper.Map<ProductReview>(request.productReviewDto);
            if (productReview is null)
            {
                Log.Error("Failed to map ProductReviewDto to ProductReview entity.");
                return null;
            }
            await _unitOfWork.Repository<ProductReview>().AddAsync(productReview, cancellationToken);
            var result = await _unitOfWork.CompleteAsync(cancellationToken);
            if (result <= 0)
            {
                Log.Error("Failed to save the new product review to the database.");
                return null;
            }
            var productReviewToReturnDto = _mapper.Map<ProductReviewsToReturnDto>(productReview);
            return productReviewToReturnDto;
        }
        catch (Exception ex)
        {
            Log.Error("Error in {ClassName} - {MethodName}: {ErrorMessage}",
                nameof(CreateProductReviewCommandHandler),
                nameof(Handle), ex.Message);

            return null;
        }
    }
}
