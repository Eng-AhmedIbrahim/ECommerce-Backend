namespace Ecommerce.Infrastructure.Services.ProductServices.ProductAttributeServices;

public partial class ProductAttributeService
{
    public async Task<bool> DeleteAttributeAsync(int attId, 
        CancellationToken cancellationToken)
    {
        if (attId <= 0)
            return await Task.FromResult(false);

        try
        {
           await _unitOfWork.Repository<ProductAttribute>()
                .ExecuteDeleteAsync(att => att.Id == attId, cancellationToken);

            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error in DeleteAttributeAsync");
            return await Task.FromResult(false);
        }
    }
}