namespace Ecommerce.Api.Base;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseApiController(IMediator mediator)
     =>   _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
}