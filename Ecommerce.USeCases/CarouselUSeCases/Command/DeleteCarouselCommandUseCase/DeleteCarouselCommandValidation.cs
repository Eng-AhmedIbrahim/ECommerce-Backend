namespace Ecommerce.UseCases.CarouselUSeCases.Command.DeleteCarouselCommandUseCase;

public class DeleteCarouselCommandValidation : AbstractValidator<DeleteCarouselCommand>
{
    public DeleteCarouselCommandValidation()
        => RuleFor(x => x.carouselId)
            .GreaterThan(0)
            .WithMessage("Carousel Id must be greater than 0");
}