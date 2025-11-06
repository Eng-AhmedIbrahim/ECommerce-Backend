namespace Ecommerce.Api.Controllers.CartControllers;

public class CartController : BaseApiController
{
    private readonly ICartService _cartService;

    public CartController(IMediator mediator, ICartService cartService) : base(mediator)
        => _cartService = cartService;

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCart(string userId, CancellationToken cancellationToken)
    {
        try
        {
            var cart = await _cartService.GetCartAsync(userId, cancellationToken);
            return Ok(cart);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("{userId}/add")]
    public async Task<IActionResult> AddToCart(string userId, [FromBody] CartItem item,
        CancellationToken cancellationToken)
    {
        try
        {
            var cart = await _cartService.AddToCartAsync(userId, item, cancellationToken);
            return Ok(cart);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


    [HttpPut("{userId}/update")]
    public async Task<IActionResult> UpdateCartItem(string userId,
        [FromBody] CartItem item,
        CancellationToken cancellationToken)
    {
        try
        {
            var cart = await _cartService.UpdateCartItemAsync(userId, item, cancellationToken);
            return Ok(cart);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{userId}/remove/{productId}")]
    public async Task<IActionResult> RemoveCartItem(string userId,
        int productId,
        CancellationToken cancellationToken)
    {
        try
        {
            var cart = await _cartService.RemoveCartItemAsync(userId, productId, cancellationToken);
            return Ok(cart);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


    [HttpDelete("{userId}/clear")]
    public async Task<IActionResult> ClearCart(string userId,
        CancellationToken cancellationToken)
    {
        try
        {
            var cart = await _cartService.ClearCartAsync(userId, cancellationToken);
            return Ok(cart);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
