namespace Ecommerce.Infrastructure.Services.ProductServices.ProductAttributeServices;

public partial class ProductAttributeService
{
    public async Task<ProductAttributeToReturnDto?> UpdateAttributeAsync(int attId,
        ProductAttributeDto attribute,
        CancellationToken cancellationToken)
    {
        if (attId <= 0 || attribute is null)
            return null;

        try
        {
            await _unitOfWork.BeginTransactionAsync();
            var existingAttribute = await _unitOfWork.Repository<ProductAttribute>()
                .GetByIdAsync(attId, cancellationToken);

            if (existingAttribute == null) return null;

            _mapper.Map(attribute, existingAttribute);

            var result = await _unitOfWork.CompleteAsync(cancellationToken);
            if (result <= 0) return null;
            
            await _unitOfWork.CommitTransactionAsync();
            
            var returnDto= _mapper.Map<ProductAttributeToReturnDto>(existingAttribute);
            return returnDto;
        }   
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Log.Error(ex, "Error in UpdateAttributeAsync");
            return null;
        }
    }
}
