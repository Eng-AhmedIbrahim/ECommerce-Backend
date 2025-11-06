global using Ecommerce.Interfaces.Infrastructure.Interfaces.WishlistServices;

namespace Ecommerce.Infrastructure.Services.WishlistServices;

public partial class WishlistService : IWishlistService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public WishlistService(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
}
