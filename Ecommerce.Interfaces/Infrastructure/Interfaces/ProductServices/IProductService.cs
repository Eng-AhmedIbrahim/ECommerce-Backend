namespace Ecommerce.Interfaces.Infrastructure.Interfaces.ProductServices;

public interface IProductService
{
    public Task<ProductToReturnDto?> CreateProductAsync(ProductDto product,CancellationToken cancellationToken);
    public Task<ProductToReturnDto?> GetProductByIdAsync(int productId,CancellationToken cancellationToken);
    public Task<ICollection<ProductToReturnDto>?> GetProductsAsync(ISpecifications<Product> specs,
        CancellationToken cancellationToken);
    public Task<bool> DeleteProductAsync(int productId,CancellationToken cancellationToken);
    public Task<ProductToReturnDto?> UpdateProductAsync(int productId,
        UpdatedProductDto productDto,CancellationToken cancellationToken);
}