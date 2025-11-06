namespace Ecommerce.Infrastructure.Services.ProductServices.ProductAttributeServices;

public partial class ProductAttributeService
{
    public async Task<IReadOnlyList<ProductAttributeToReturnDto>?> GetAllAttributesAsync(CancellationToken cancellationToken)
    {
        try
        {
            var productAttributes = await _unitOfWork.Repository<ProductAttribute>()
                .GetAllAsNoTrackingAsync(cancellationToken);
            if (productAttributes is null || !productAttributes.Any())
                return null;

            return _mapper.Map<IReadOnlyList<ProductAttribute>, IReadOnlyList<ProductAttributeToReturnDto>>(productAttributes);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error in GetAllAttributesAsync");
            return null;
        }
    }

    public async Task<ProductAttributeToReturnDto?> GetAttributeByIdAsync(int attId, CancellationToken cancellationToken)
    {
        try
        {
            var productAttribute = await _unitOfWork.Repository<ProductAttribute>().GetByIdAsNotTrackingAsync(attId, cancellationToken);
            if (productAttribute is null) return null;

            return _mapper.Map<ProductAttribute, ProductAttributeToReturnDto>(productAttribute);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error in GetAttributeAsync");
            return null;
        }
    }
}
