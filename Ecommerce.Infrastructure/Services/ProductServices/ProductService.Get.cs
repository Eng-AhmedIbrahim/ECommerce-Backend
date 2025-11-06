namespace Ecommerce.Infrastructure.Services.ProductServices;

public partial class ProductService
{
    public async Task<ProductToReturnDto?> GetProductByIdAsync(int productId,
        CancellationToken cancellationToken)
    {
        try
        {
            var productSpecs = new ProductWithIncludesSpecs(productId);

            var product = await _unitOfWork.Repository<Product>()
                .GetByIdWithSpecsWithTrackingAsync(productSpecs, cancellationToken);

            if (product == null) return null;

            var productToReturnDto = _mapper.Map<ProductToReturnDto>(product);

            if (productToReturnDto == null) return null;

            return productToReturnDto;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error in GetProductByIdAsync: {Message}", ex.Message);
            return null;
        }
    }

    public async Task<ICollection<ProductToReturnDto>?> GetProductsAsync(ISpecifications<Product> productsSpecs, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _unitOfWork.Repository<Product>()
                .GetAllWithSpecsAsNoTrackingAsync(productsSpecs, cancellationToken);
            
            return _mapper.Map<ICollection<ProductToReturnDto>>(products);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Error in GetProductsAsync: {ex.Message}");
            return null;
        }
    }
}