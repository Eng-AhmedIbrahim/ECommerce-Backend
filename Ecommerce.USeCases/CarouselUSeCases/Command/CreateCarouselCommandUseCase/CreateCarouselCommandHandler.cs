namespace Ecommerce.UseCases.CarouselUSeCases.Command.CreateCarouselCommandUseCase;

public class CreateCarouselCommandHandler : IRequestHandler<CreateCarouselCommand, CarouselToReturnDto?>
{
    private readonly ICarouselService _carouselService;

    public CreateCarouselCommandHandler(ICarouselService carouselService)
     => _carouselService = carouselService;

    public async Task<CarouselToReturnDto?> Handle(CreateCarouselCommand request, CancellationToken cancellationToken)
         => await _carouselService.CreateCarouselAsync(request.CarouselDto, cancellationToken);
}