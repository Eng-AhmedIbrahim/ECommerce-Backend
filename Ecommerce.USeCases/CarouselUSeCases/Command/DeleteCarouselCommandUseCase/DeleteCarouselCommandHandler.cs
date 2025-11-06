namespace Ecommerce.UseCases.CarouselUSeCases.Command.DeleteCarouselCommandUseCase;

public class DeleteCarouselCommandHandler : IRequestHandler<DeleteCarouselCommand, bool>
{
    private readonly ICarouselService _carouselService;
    public DeleteCarouselCommandHandler(ICarouselService carouselService)
     => _carouselService = carouselService;
    public async Task<bool> Handle(DeleteCarouselCommand request, CancellationToken cancellationToken)
         => await _carouselService.DeleteCarouselAsync(request.carouselId, cancellationToken);
}