namespace Ecommerce.Infrastructure.Services.ProductServices.ProductAttributeServices;

public partial class ProductAttributeService
{
    public async Task<ProductAttributeToReturnDto?> CreateAttributeAsync(ProductAttributeDto attribute, CancellationToken cancellationToken)
    {
        try
        {
            var mappedAttribute = _mapper.Map<ProductAttribute>(attribute);
            await _unitOfWork.Repository<ProductAttribute>().AddAsync(mappedAttribute, cancellationToken);
            var result = await _unitOfWork.CompleteAsync(cancellationToken);
            if (result <= 0) return null;
            return _mapper.Map<ProductAttribute, ProductAttributeToReturnDto>(mappedAttribute);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error in CreateAttributeAsync");
            return null;
        }
    }
}
