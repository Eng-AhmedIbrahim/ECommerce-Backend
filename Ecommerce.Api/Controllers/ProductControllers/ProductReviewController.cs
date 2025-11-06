namespace Ecommerce.Api.Controllers.ProductControllers;

public class ProductReviewController : BaseApiController
{
    public ProductReviewController(IMediator mediator) : base(mediator)
    {}


    [HttpPost("add-review")]
    public async Task<IActionResult> CreateProductReview([FromBody] ProductReviewDto productReviewDto, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new CreateProductReviewCommand(productReviewDto), cancellationToken);
       
        if (result is null)
            return BadRequest("Failed to create product review.");
        
        return Ok(result);
    }
}
