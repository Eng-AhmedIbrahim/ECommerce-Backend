namespace Ecommerce.UseCases.CarouselUSeCases.Command.CreateCarouselCommandUseCase;

public record CreateCarouselCommand(CarouselDto CarouselDto) : IRequest<CarouselToReturnDto>
{ }