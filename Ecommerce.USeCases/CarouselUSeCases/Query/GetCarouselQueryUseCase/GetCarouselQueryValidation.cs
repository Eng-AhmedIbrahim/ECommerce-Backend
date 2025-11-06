namespace Ecommerce.UseCases.CarouselUSeCases.Query.GetCarouselQueryUseCase;

public class GetCarouselQueryValidation : AbstractValidator<GetCarouselQuery>
{
    public GetCarouselQueryValidation()
    {
        RuleFor(x => x.carouselId)
            .GreaterThan(0)
            .WithMessage("Carousel Id must be greater than 0");
    }
}