namespace Ecommerce.Infrastructure.Services.CarouselServices;

public class CarouselService : ICarouselService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinary;

    public CarouselService(IUnitOfWork unitOfWork,IMapper mapper,ICloudinaryService cloudinary)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        this._cloudinary = cloudinary;
    }
    public async Task<CarouselToReturnDto?> CreateCarouselAsync(CarouselDto carouselToCreateDto,
      CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var repo = _unitOfWork.Repository<Carousel>();
            var carouselEntity = _mapper.Map<Carousel>(carouselToCreateDto);

            var imgUrl = await _cloudinary.UploadImageAsync(carouselToCreateDto.ImageUrl);

            if(string.IsNullOrEmpty(imgUrl))
            {
                Log.Error("Image upload failed for carousel with data {@CarouselDto}", carouselToCreateDto);
                await _unitOfWork.RollbackTransactionAsync();
                return null;
            }

            carouselEntity.ImageUrl = imgUrl;

            await repo.AddAsync(carouselEntity, cancellationToken);

            var result = await _unitOfWork.CompleteAsync(cancellationToken);
            if (result <= 0)
            {
                await _unitOfWork.RollbackTransactionAsync();
                Log.Error("Failed to create carousel for data {@CarouselDto}", carouselToCreateDto);
                return null;
            }

            await _unitOfWork.CommitTransactionAsync();
            Log.Information("Carousel created successfully with id {CarouselId}", carouselEntity.Id);
            return _mapper.Map<CarouselToReturnDto>(carouselEntity);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Log.Error(ex, "Error occurred while creating carousel with data {@CarouselDto}", carouselToCreateDto);
            return null;
        }
    }

    public async Task<bool> DeleteCarouselAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var repo = _unitOfWork.Repository<Carousel>();
            var carousel = await repo.GetByIdAsync(id, cancellationToken);

            if (carousel is null)
            {
                Log.Warning("Carousel with id {CarouselId} not found", id);
                return false;
            }

            await repo.ExecuteDeleteAsync(c => c.Id == id, cancellationToken);

            Log.Information("Carousel with id {CarouselId} deleted successfully", id);
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error occurred while deleting carousel with id {CarouselId}", id);
            return false;
        }
    }

    public async Task<IReadOnlyList<CarouselToReturnDto>?> GetAllCarouselsAsync(CancellationToken cancellationToken)
    {
        try
        {
            var repo = _unitOfWork.Repository<Carousel>();
            var carousels = await repo.GetAllAsync(cancellationToken);

            if (carousels is null || !carousels.Any())
                return null;

            return _mapper.Map<IReadOnlyList<CarouselToReturnDto>>(carousels);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error occurred while retrieving carousels");
            return null;
        }
    }

    public async Task<CarouselToReturnDto?> GetCarouselByIdAsync(int id,
        CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Carousel>();
        try
        {
            var carousel = await repo.GetByIdAsync(id, cancellationToken);
            if (carousel is null)
            {
                Log.Warning("Carousel with id {CarouselId} not found", id);
                return null;
            }
            return _mapper.Map<CarouselToReturnDto>(carousel);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error occurred while retrieving carousel with id {CarouselId}", id);
            return null;
        }
    }

    public async Task<CarouselToReturnDto?> UpdateCarouselAsync(
     int id,
     CarouselDto carouselToUpdateDto,
     CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.Repository<Carousel>();
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var existingCarousel = await repo.GetByIdAsync(id, cancellationToken);
            if (existingCarousel is null)
            {
                Log.Warning("Carousel with id {CarouselId} not found", id);
                await _unitOfWork.RollbackTransactionAsync();
                return null;
            }

            if (carouselToUpdateDto.ImageUrl is not null)
            {
                var newImgUrl = await _cloudinary.UploadImageAsync(carouselToUpdateDto.ImageUrl);
                if (string.IsNullOrEmpty(newImgUrl))
                {
                    Log.Error("Image upload failed while updating carousel with id {CarouselId}", id);
                    await _unitOfWork.RollbackTransactionAsync();
                    return null;
                }

                existingCarousel.ImageUrl = newImgUrl;
            }

            _mapper.Map(carouselToUpdateDto, existingCarousel);

            await repo.UpdateAsync(existingCarousel);

            var result = await _unitOfWork.CompleteAsync(cancellationToken);
            if (result <= 0)
            {
                Log.Error("Failed to update carousel with id {CarouselId}. Data: {@CarouselDto}", id, carouselToUpdateDto);
                await _unitOfWork.RollbackTransactionAsync();
                return null;
            }

            await _unitOfWork.CommitTransactionAsync();
            Log.Information("Carousel with id {CarouselId} updated successfully", id);

            return _mapper.Map<CarouselToReturnDto>(existingCarousel);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Log.Error(ex, "Error occurred while updating carousel with id {CarouselId}", id);
            return null;
        }
    }
}