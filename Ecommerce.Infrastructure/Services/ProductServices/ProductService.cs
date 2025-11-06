namespace Ecommerce.Infrastructure.Services.ProductServices;

public partial class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinary;

    public ProductService(IUnitOfWork unitOfWork
        , IMapper mapper
        , ICloudinaryService cloudinary)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cloudinary = cloudinary;
    }
}