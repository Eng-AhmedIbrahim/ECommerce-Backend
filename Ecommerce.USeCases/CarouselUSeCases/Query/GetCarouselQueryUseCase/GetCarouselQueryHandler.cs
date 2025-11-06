namespace Ecommerce.UseCases.CarouselUSeCases.Query.GetCarouselQueryUseCase;

public class GetCarouselQueryHandler : IRequestHandler<GetCarouselQuery, CarouselToReturnDto?>
{
    private readonly ICarouselService _carouselService;
    public GetCarouselQueryHandler(ICarouselService carouselService)
        => _carouselService = carouselService;
    public async Task<CarouselToReturnDto?> Handle(GetCarouselQuery request, CancellationToken cancellationToken)
       => await _carouselService.GetCarouselByIdAsync(request.carouselId, cancellationToken);
}