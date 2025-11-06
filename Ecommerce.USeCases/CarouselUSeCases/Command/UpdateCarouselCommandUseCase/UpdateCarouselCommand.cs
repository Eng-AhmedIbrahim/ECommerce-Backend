namespace Ecommerce.UseCases.CarouselUSeCases.Command.UpdateCarouselCommandUseCase;

public record UpdateCarouselCommand(int id,CarouselDto CarouselDto) : IRequest<CarouselToReturnDto?>
{ }