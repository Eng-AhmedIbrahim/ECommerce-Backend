namespace Ecommerce.Infrastructure.Services.ProductServices;

public partial class ProductService
{
    public async Task<ProductToReturnDto?> UpdateProductAsync(int productId,
        UpdatedProductDto productDto, CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            await _unitOfWork.Repository<Product>()
                .ExecuteUpdateAsync(
                     p => p.Id == productId,
                     p => p
                        .SetProperty(pr => pr.ArabicName, productDto.ArabicName)
                        .SetProperty(pr => pr.EnglishName, productDto.EnglishName)
                        .SetProperty(pr => pr.ArabicDescription, productDto.ArabicDescription)
                        .SetProperty(pr => pr.EnglishDescription, productDto.EnglishDescription)
                        .SetProperty(pr => pr.Price, productDto.Price)
                        .SetProperty(pr => pr.DiscountPercentage, productDto.DiscountPercentage)
                        .SetProperty(pr => pr.StockQuantity, productDto.StockQuantity)
                        .SetProperty(pr => pr.IsActive, productDto.IsActive)
                        .SetProperty(pr => pr.CategoryId, productDto.CategoryId),
                    cancellationToken
                );

            if (productDto.Attributes is not null && productDto.Attributes.Any())
            {
                var atttRepo
                     = _unitOfWork.Repository<ProductVariant>();

                await atttRepo.ExecuteDeleteAsync(a => a.ProductId == productId, cancellationToken);

                foreach (var attr in productDto.Attributes)
                {
                    string? attributeImageUrl = null;

                    if (attr.AttributeImage is not null)
                    {
                        var attributeImagePath = await _cloudinary
                            .UploadImageAsync(attr.AttributeImage);
                    }

                    await atttRepo.AddAsync(new ProductVariant
                    {
                        ProductId = productId,
                        ProductAttributeId = attr.AttributeId,
                        EnglishValue = attr.EnglishValue,
                        ArabicValue = attr.ArabicValue,
                        Price = attr.Price,
                        StockQuantity = attr.StockQuantity,
                        ImageUrl = attributeImageUrl
                    }, cancellationToken);
                }
            }
            await _unitOfWork.CommitTransactionAsync();
            return await GetProductByIdAsync(productId, cancellationToken) ?? null;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Log.Error(ex, $"Error in UpdateProductAsync: {ex.Message}");
            return null;
        }
    }
}