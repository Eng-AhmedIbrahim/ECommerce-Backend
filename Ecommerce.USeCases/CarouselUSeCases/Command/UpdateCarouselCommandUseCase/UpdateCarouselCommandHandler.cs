namespace Ecommerce.UseCases.CarouselUSeCases.Command.UpdateCarouselCommandUseCase;

public class UpdateCarouselCommandHandler : IRequestHandler<UpdateCarouselCommand, CarouselToReturnDto?>
{
    private readonly ICarouselService _carouselService;
    public UpdateCarouselCommandHandler(ICarouselService carouselService)
     => _carouselService = carouselService;
    public async Task<CarouselToReturnDto?> Handle(UpdateCarouselCommand request, CancellationToken cancellationToken)
         => await _carouselService.UpdateCarouselAsync(request.id,request.CarouselDto, cancellationToken);
}