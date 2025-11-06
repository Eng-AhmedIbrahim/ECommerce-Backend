using Ecommerce.Domain.Entities.ProductEntities;
using Ecommerce.Domain.Specifications.ProductSpecifications;
using Ecommerce.Interfaces.Persistence;

namespace Ecommerce.Api.Controllers.ProductControllers;

public class ProductController : BaseApiController
{
    private readonly ICloudinaryService cloudinaryService;
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IMediator mediator,
        ICloudinaryService cloudinaryService,
        IUnitOfWork unitOfWork) : base(mediator)
    {
        this.cloudinaryService = cloudinaryService;
        this._unitOfWork = unitOfWork;
    }

    [HttpPost("create-Product")]
    public async Task<IActionResult> CreateProductAsync(ProductDto productDto)
    {
        var productToReturnDto = await _mediator.Send(new CreateProductCommand(productDto));
        if (productToReturnDto == null)
            return BadRequest(new ApiResponse(400, "Failed to create product."));

        return Ok(productToReturnDto);
    }

    //[HttpPost("create-product")]
    //public async Task<IActionResult> CreateProductAsync(ProductDto productDto)
    //{
    //    if (!string.IsNullOrEmpty(productDto.AttributesJson))
    //    {
    //        var options = new JsonSerializerOptions
    //        {
    //            PropertyNameCaseInsensitive = true
    //        };

    //        try
    //        {
    //            var attributes = JsonSerializer.Deserialize<List<ProductAttributeValueDto>>(
    //                productDto.AttributesJson,
    //                options
    //            );

    //            productDto.Attributes = attributes;
    //        }
    //        catch (JsonException)
    //        {
    //            return BadRequest(new ApiResponse(400, "Invalid format for product attributes JSON."));
    //        }
    //    }

    //    var productToReturnDto = await _mediator.Send(new CreateProductCommand(productDto));

    //    if (productToReturnDto == null)
    //        return BadRequest(new ApiResponse(400, "Failed to create product."));

    //    return Ok(productToReturnDto);
    //}

    [HttpGet("get-product/{productId}")]
    public async Task<IActionResult> GetProductAsync(int productId)
    {
        var productToReturnDto = await _mediator.Send(new GetProductByIdQuery(productId));

        if (productToReturnDto == null)
            return BadRequest(new ApiResponse(400, "Failed to get product."));

        return Ok(productToReturnDto);
    }

    [HttpGet("get-products")]
    public async Task<IActionResult> GetProductsAsync()
    {
        var specs = new ProductWithIncludesSpecs();
        var products = await _mediator.Send(new GetProductsQuery(specs));
        if (products is null)
        {
            Log.Warning("No products found in the database.");
            return BadRequest(new ApiResponse(400, "Failed to get products."));
        }
        return Ok(products);
    }

    [HttpDelete("delete-product/{productId}")]
    public async Task<IActionResult> DeleteProductAsync(int productId)
    {
        var result = await _mediator.Send(new DeleteProductCommand(productId));
        if (!result)
        {
            Log.Error("Failed to delete product with ID {ProductId}.", productId);
            return BadRequest(new ApiResponse(400, "Failed to delete product."));
        }
        return Ok(new ApiResponse(200, "Product deleted successfully."));
    }

    [HttpPatch("update-product/{productId}")]
    public async Task<IActionResult> UpdateProductAsync(int productId,
        [FromBody] UpdatedProductDto productDto)
    {
        var updatedProduct = await _mediator.Send(new UpdateProductCommand(productId, productDto));
        if (updatedProduct is null)
        {
            Log.Error("Failed to update product with ID {ProductId}.", productId);
            return BadRequest(new ApiResponse(400, "Failed to update product."));
        }
        return Ok(updatedProduct);
    }


    [HttpGet("get-products-with-specs")]
    public async Task<IActionResult> GetProductsBySpecificationsAsync([FromQuery] ProductSpecParams specParams,
        CancellationToken cancellationToken)
    {

        var specs = new ProductWithIncludesAndPaginationSpecs(specParams);
        var products = await _mediator.Send(new GetProductsQuery(specs));
        if (products is null)
        {
            Log.Warning("No products found matching the given specifications.");
            return NotFound(new ApiResponse(404, "No products found matching the given specifications."));
        }

        var productCountSpecs = new ProductCountSpecs(specParams.CategoryId);

        var productCount = await _unitOfWork.Repository<Product>()
            .GetCountAsync(productCountSpecs, cancellationToken);

        var returnedData = new Pagination<ProductToReturnDto>(
             specParams.PageIndex,
             specParams.PageSize,
             productCount,
             products.ToList()
        );

        return Ok(returnedData);
    }
}
