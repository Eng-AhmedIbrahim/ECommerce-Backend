namespace Ecommerce.UseCases.CarouselUSeCases.Query.GetCarouselQueryUseCase;

public record GetCarouselQuery(int carouselId) : IRequest<CarouselToReturnDto?>
{ }