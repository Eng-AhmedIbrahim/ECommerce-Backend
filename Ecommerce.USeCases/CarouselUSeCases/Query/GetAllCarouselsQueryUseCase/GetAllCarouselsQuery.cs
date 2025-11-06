namespace Ecommerce.UseCases.CarouselUSeCases.Query.GetAllCarouselsQueryUseCase;

public record GetAllCarouselsQuery : IRequest<IReadOnlyList<CarouselToReturnDto>>
{ }