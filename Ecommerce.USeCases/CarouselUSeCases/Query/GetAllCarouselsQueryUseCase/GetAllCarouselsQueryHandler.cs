namespace Ecommerce.UseCases.CarouselUSeCases.Query.GetAllCarouselsQueryUseCase;

public class GetAllCarouselsQueryHandler : IRequestHandler<GetAllCarouselsQuery, IReadOnlyList<CarouselToReturnDto>?>
{
    private readonly ICarouselService _carouselService;

    public GetAllCarouselsQueryHandler(ICarouselService carouselService)
        => _carouselService = carouselService;
    public async Task<IReadOnlyList<CarouselToReturnDto>?> Handle(GetAllCarouselsQuery request, CancellationToken cancellationToken)
      => await _carouselService.GetAllCarouselsAsync(cancellationToken);
}