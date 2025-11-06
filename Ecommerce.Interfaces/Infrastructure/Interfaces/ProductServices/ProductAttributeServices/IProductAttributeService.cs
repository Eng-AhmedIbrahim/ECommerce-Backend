namespace Ecommerce.Interfaces.Infrastructure.Interfaces.ProductServices.ProductAttributeServices;

public interface IProductAttributeService
{
    public Task<IReadOnlyList<ProductAttributeToReturnDto>?> GetAllAttributesAsync(
        CancellationToken cancellationToken);
    public Task<ProductAttributeToReturnDto?> GetAttributeByIdAsync(int attId,
        CancellationToken cancellationToken);
    public Task<ProductAttributeToReturnDto?> CreateAttributeAsync(ProductAttributeDto attribute, 
        CancellationToken cancellationToken);

    public Task<ProductAttributeToReturnDto?> UpdateAttributeAsync(int attId, ProductAttributeDto attribute, 
        CancellationToken cancellationToken);

    public Task<bool> DeleteAttributeAsync(int attId, 
        CancellationToken cancellationToken);
}