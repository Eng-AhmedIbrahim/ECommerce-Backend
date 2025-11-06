namespace Ecommerce.Infrastructure.Services.ProductServices;

public partial class ProductService
{
    public async Task<bool> DeleteProductAsync(int productId, CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.Repository<Product>()
                .ExecuteDeleteAsync(p => p.Id == productId, cancellationToken);
            await _unitOfWork.CommitTransactionAsync();
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Log.Error(ex, $"Error in DeleteProductAsync: {ex.Message}");
            return await Task.FromResult(false);
        }
    }
}