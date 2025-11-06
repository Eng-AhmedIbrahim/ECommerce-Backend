namespace Ecommerce.Api.Controllers.CarouselController;

public class CarouselController : BaseApiController
{
    public CarouselController(IMediator mediator) :
        base(mediator)
    { }

    [HttpPost("create-carousel")]
    public async Task<IActionResult> CreateCarousel([FromForm] CarouselDto carouselToCreateDto, CancellationToken cancellationToken)
    {
       
        var result = await _mediator.Send(new CreateCarouselCommand(carouselToCreateDto), 
            cancellationToken);
        if (result is null) 
            return BadRequest("Failed to create carousel.");
        
        return Ok(result);
    }
    [HttpDelete("delete-carousel")]
    public async Task<IActionResult> DeleteCarousel(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteCarouselCommand(id), cancellationToken);
        if (!result) 
            return BadRequest("Failed to delete carousel.");
        
        return Ok("Carousel deleted successfully.");
    }
    [HttpGet("get-carousel/{carouselId}")]
    public async Task<IActionResult> GetCarouselById(int carouselId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCarouselQuery(carouselId), cancellationToken);
        if (result is null) 
            return NotFound("Carousel not found.");
        
        return Ok(result);
    }

    [HttpGet("get-carousels")]
    public async Task<IActionResult> GetAllCarousels(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllCarouselsQuery(),
            cancellationToken);
        if (result is null || !result.Any()) 
            return NotFound("No carousels found.");
        
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCarousel(int carouselId,CarouselDto carouselDto, CancellationToken cancellationToken)
    {
       var result = await _mediator.Send(
           new UpdateCarouselCommand(carouselId,carouselDto), cancellationToken);
         if (result is null)
                return BadRequest("Failed to update carousel.");

         return Ok(result);
    }
}