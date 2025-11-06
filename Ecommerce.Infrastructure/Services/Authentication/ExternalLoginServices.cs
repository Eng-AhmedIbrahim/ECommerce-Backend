namespace Ecommerce.Infrastructure.Services.Authentication;

public class ExternalLoginServices : IExternalLoginServices
{
    public UserManager<AppUser> _userManager;
    private readonly AppDbContext _appDbContext;
    private readonly IAuthenticationService _authenticationService;

    public ExternalLoginServices(UserManager<AppUser> userManager,
        AppDbContext appDbContext,
        IAuthenticationService authenticationService)
    {
        _userManager = userManager;
        _appDbContext = appDbContext;
        _authenticationService = authenticationService;
    }

    public async Task<LoginResponseDto?> SignInWithGoogle(GoogleSignInVM model,CancellationToken cancellationToken)
    {
        Payload payload = new();

        try
        {
            payload = await ValidateAsync(model.IdToken, new ValidationSettings
            {
                Audience = new[] { model.ClientId }
            });
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error validating Google ID token");
            return null;
        }

        var userToBeCreated = new CreateUserFromSocialLogin
        {
            UserName = payload.Name ?? payload.Email,
            Email = payload.Email,
            ProfilePicture = payload.Picture,
            LoginProviderSubject = payload.Subject
        };

        var loginResponse = await _userManager.
            CreateUserFromSocialLogin(_appDbContext, userToBeCreated, LoginProvider.Google, _authenticationService);

        if(loginResponse == null)
        {
            Log.Error("Error creating or retrieving user from Google login");
            return null;
        }

        return loginResponse;
    }
}