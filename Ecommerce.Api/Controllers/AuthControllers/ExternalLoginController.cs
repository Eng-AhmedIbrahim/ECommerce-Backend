namespace Ecommerce.Api.Controllers.AuthControllers;

public class ExternalLoginController : BaseApiController
{
    public ExternalLoginController(IMediator mediator) : base(mediator)
    { }

    [HttpPost("signin-google")]
    public async Task<IActionResult> GoogleSignIn([FromBody] GoogleSignInVM signInModel)
    {
        var result = await _mediator.Send(new GoogleSignInCommand(signInModel));
        if (result is null)
            return BadRequest(new ApiResponse(400, "Google Sign-In failed"));
        
        return Ok(result);
    }
}