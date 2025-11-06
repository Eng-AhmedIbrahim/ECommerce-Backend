namespace Ecommerce.UseCases.CarouselUSeCases.Command.DeleteCarouselCommandUseCase;

public record DeleteCarouselCommand(int carouselId) : IRequest<bool>
{ }