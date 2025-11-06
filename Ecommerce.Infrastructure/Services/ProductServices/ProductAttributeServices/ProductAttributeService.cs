
namespace Ecommerce.Infrastructure.Services.ProductServices.ProductAttributeServices;

public partial class ProductAttributeService : IProductAttributeService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductAttributeService(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
}
