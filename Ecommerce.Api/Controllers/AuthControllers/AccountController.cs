namespace Ecommerce.Api.Controllers.AuthControllers;

public class AccountController : BaseApiController
{
    private const string RefreshTokenCookieName = "refreshToken";
    private readonly IMapper _mapper;

    public AccountController(IMediator mediator, IMapper mapper)
        : base(mediator) {
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(SignUpDto userDto)
    {
        var createUserCommand = _mapper.Map<SignUpDto, CreateUserCommand>(userDto);

        var result = await _mediator.Send(createUserCommand);
        if (!string.IsNullOrEmpty(result!.Message))
            return BadRequest(new ApiResponse(400, result.Message));

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var loginUser = _mapper.Map<LoginDto, LoginCommand>(loginDto);
        var result = await _mediator.Send(loginUser);

        SetRefreshTokenCookie(result.RefreshToken, result.RefreshTokenExpiresOn);

        if (result is null)
            return BadRequest(new ApiResponse(400, "User could not Login"));

        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] string tokenRequest)
    {
        var refreshToken = Request.Cookies["refreshToken"];
        if (string.IsNullOrEmpty(refreshToken))
            return Unauthorized(new ApiResponse(401, "No refresh token found"));

        var loginDto = await _mediator.Send(new RefreshTokenCommand(refreshToken));
        if (loginDto is null)
            return BadRequest(new ApiResponse(400, "Token could not be refreshed"));

        SetRefreshTokenCookie(loginDto.RefreshToken, loginDto.RefreshTokenExpiresOn);
        return Ok(loginDto);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await _mediator.Send(new LogoutCommand());

        if (!result)
        {
            Log.Error("Logout failed for user {UserName}", User.Identity?.Name);
            return BadRequest(new ApiResponse(400, "User could not Logout"));
        }

        return Ok(result);
    }

    private void SetRefreshTokenCookie(string refreshToken, DateTime expiresOn)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = expiresOn,
            Secure = false,
            IsEssential = true,
            SameSite = SameSiteMode.None
        };
        Response.Cookies.Append(RefreshTokenCookieName, refreshToken, cookieOptions);
    }
}