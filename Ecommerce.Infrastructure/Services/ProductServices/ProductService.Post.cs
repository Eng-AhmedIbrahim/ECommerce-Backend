namespace Ecommerce.Infrastructure.Services.ProductServices;

public partial class ProductService
{
    public async Task<ProductToReturnDto?> CreateProductAsync(ProductDto product, 
        CancellationToken cancellationToken)
    {
         await _unitOfWork.BeginTransactionAsync();

        try
        {
            if (product.Images == null || !product.Images.Any())
            {
                Log.Error("No images were provided for the product.");
                await _unitOfWork.RollbackTransactionAsync();
                return null;
            }

            var newProduct = _mapper.Map<ProductDto, Product>(product);
            await _unitOfWork.Repository<Product>().AddAsync(newProduct, cancellationToken);

            var urls = await _cloudinary.UploadImagesAsync(product.Images);
            if (urls == null || !urls.Any())
            {
                Log.Error("Failed to upload images for the product.");
                await _unitOfWork.RollbackTransactionAsync();
                return null;
            }

            var productImages = urls.Select((url, index) => new ProductImage
            {
                Url = url,
                IsMain = index == 0,
                Product = newProduct
            }).ToList();

            await _unitOfWork.Repository<ProductImage>().AddRangeAsync(productImages, cancellationToken);

            var createdVariants = new List<ProductVariant>();

            if (product.Attributes != null && product.Attributes.Any())
            {
                foreach (var attr in product.Attributes)
                {
                    var variant = new ProductVariant
                    {
                        Product = newProduct,
                        ProductAttributeId = attr.AttributeId,
                        EnglishValue = attr.EnglishValue,
                        ArabicValue = attr.ArabicValue,
                        Price = attr.Price,
                        StockQuantity = attr.StockQuantity
                    };

                    if (attr.AttributeImage != null)
                    {
                        var variantUrl = await _cloudinary.UploadImageAsync(attr.AttributeImage);
                        variant.ImageUrl = variantUrl;
                    }

                    await _unitOfWork.Repository<ProductVariant>().AddAsync(variant, cancellationToken);
                    createdVariants.Add(variant);
                }
            }

            await _unitOfWork.CompleteAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync();

            newProduct.Variants = createdVariants;

            var productToReturnDto = _mapper.Map<Product, ProductToReturnDto>(newProduct);
            productToReturnDto.Images = urls;

            return productToReturnDto;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            Log.Error(ex, "An error occurred while creating the product.");
            return null;
        }
    }
}