namespace Ecommerce.Interfaces.Infrastructure.Interfaces.CarouselServices;

public interface ICarouselService
{
    Task<CarouselToReturnDto?> CreateCarouselAsync(CarouselDto carouselToCreateDto,
        CancellationToken cancellationToken);

    Task<CarouselToReturnDto?> UpdateCarouselAsync(int id,
        CarouselDto carouselToUpdateDto,
        CancellationToken cancellationToken);

    Task<bool> DeleteCarouselAsync(int id,
        CancellationToken cancellationToken);
    Task<CarouselToReturnDto?> GetCarouselByIdAsync(int id,
        CancellationToken cancellationToken);
    Task<IReadOnlyList<CarouselToReturnDto>?> GetAllCarouselsAsync(
        CancellationToken cancellationToken);
}