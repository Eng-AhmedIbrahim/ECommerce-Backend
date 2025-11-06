namespace Ecommerce.Api.Controllers.WishlistController;

public class WishlistController : BaseApiController
{
    public WishlistController(IMediator mediator, IMapper mapper) : base(mediator)
    { }

    [HttpPost("AddItemToWishlist")]
    public async Task<IActionResult> AddItemToWishlist([FromBody] AddItemToWishlistCommand command)
    {
        var result = await _mediator.Send(command);
        return CheckWishlistReturn(result,"Added");
    }


    [HttpDelete("RemoveItemFromWishlist")]
    public async Task<IActionResult> RemoveItemFromWishlist([FromBody] RemoveItemFromWishlistCommand command)
    {
        var result = await _mediator.Send(command);

        return CheckWishlistReturn(result,"Removed");
    }

    [HttpDelete("ClearWishlist")]
    public async Task<IActionResult> ClearWishlist([FromBody] string userId)
    {
        var command = new ClearWishlistCommand(userId);
        var result = await _mediator.Send(command);

        return result switch
        {
            WishlistResult.Deleted => Ok(new ApiResponse(200, "Wishlist cleared successfully")),
            WishlistResult.Failed => BadRequest(new ApiResponse(400, "Failed to clear wishlist")),
            _ => BadRequest(new ApiResponse(400, "Unexpected error while clearing wishlist"))
        };
    }

    [HttpGet("GetWishlist")]
    public async Task<IActionResult> GetWishlist([FromQuery] string userId)
    {
        var query = new GetWishlistQuery(userId);
        var result = await _mediator.Send(query);

        if (result is null)
            return NotFound(new ApiResponse(404, "Wishlist not found"));

        return Ok(result);
    }

    private IActionResult CheckWishlistReturn(WishlistResult result,string addorRemove)
    {
        return result switch
        {
            WishlistResult.Added => Ok(new ApiResponse(200, $"Item {addorRemove} to Wishlist successfully")),
            WishlistResult.AlreadyExists => Ok(new ApiResponse(200,$"Item already exists in Wishlist")),
            WishlistResult.Failed => BadRequest(new ApiResponse(400, $"Failed to {addorRemove} item to Wishlist")),
            WishlistResult.Deleted => Ok(new ApiResponse(200,"Item Deleted Successfully")),
            WishlistResult.NotFound => BadRequest(new ApiResponse(404,"Item Is Not Found")),
            _ => BadRequest(new ApiResponse(400, $"Unexpected error while {addorRemove} item to Wishlist"))
        };
    }
}
