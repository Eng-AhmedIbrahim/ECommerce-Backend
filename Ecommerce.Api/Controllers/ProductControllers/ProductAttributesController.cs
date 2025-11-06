namespace Ecommerce.Api.Controllers.ProductControllers
{
    public class ProductAttributesController : BaseApiController
    {
        public ProductAttributesController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet("product-attributes")]
        public async Task<IActionResult> GetAllAttributes(CancellationToken cancellationToken)
        {
            var productAttributes = await _mediator.Send(new GetAllAttributesQuery());
            if (productAttributes is null)
                return NotFound(new ApiResponse(404, "No product attributes found."));

            return Ok(productAttributes);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetAttributesByProduct(int productId, 
            CancellationToken cancellationToken)
        {
            var returnDto = await _mediator.Send(new GetAttributeByIdQuery(productId), cancellationToken);
            if (returnDto is null)
            {
                Log.Warning("No product attributes found for ProductId: {ProductId}", productId);
                return NotFound(new ApiResponse(404, "No product attributes found."));
            }

            return Ok(returnDto);
        }

        [HttpPost("product-attributes")]
        public async Task<IActionResult> CreateAttribute([FromBody] ProductAttributeDto attributeDto, 
            CancellationToken cancellationToken)
        {
            var returnDto= await _mediator.Send(new CreateProductAttributeCommand(attributeDto), cancellationToken);
            if (returnDto is null)
            {
                Log.Warning("Failed to create product attribute for AttributeName: {AttributeName}", attributeDto.EnglishName);
                return BadRequest(new ApiResponse(400, "Failed to create product attribute."));
            }
            return Ok(returnDto);
        }

        [HttpDelete("delete-attribute/{attId}")]
        public async Task<IActionResult> DeleteAttribute(int attId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteProductAttributeCommand(attId), cancellationToken);
            if (!result)
            {
                Log.Warning("Failed to delete product attribute for AttributeId: {AttributeId}", attId);
                return NotFound(new ApiResponse(404, "Product attribute not found."));
            }
            return Ok(new ApiResponse(200, "Product attribute deleted successfully."));
        }

        [HttpPut("update-attribute/{attId}")]
        public async Task<IActionResult> UpdateAttribute(int attId,[FromBody] ProductAttributeDto attributeDto, 
            CancellationToken cancellationToken)
        {
            if (attId <= 0)
            {
                Log.Warning("Invalid AttributeId: {AttributeId}", attId);
                return BadRequest(new ApiResponse(400, "Invalid AttributeId."));
            }
            var returnDto = await _mediator.Send(new UpdateProductAttributeCommand(attId,attributeDto), cancellationToken);
            if (returnDto is null)
            {
                Log.Warning("Failed to update product attribute for AttributeId: {AttributeId}", attId);
                return NotFound(new ApiResponse(404, "Product attribute not found."));
            }
            return Ok(returnDto);
        }
    }
}