namespace Ecommerce.Infrastructure.Services.Authentication;

public class AccountServices : IAccountServices
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IAuthenticationService _authService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppIdentityDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountServices(
        UserManager<AppUser> userManager,
        IMapper mapper,
        SignInManager<AppUser> signInManager,
        IAuthenticationService authService,
        RoleManager<IdentityRole> roleManager,
        AppIdentityDbContext context,
        IHttpContextAccessor httpContextAccessor
        )
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
        _authService = authService;
        _roleManager = roleManager;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<LoginResponseDto?> RegisterAsync(SignUpDto user)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (await _userManager.FindByEmailAsync(user.Email) is not null)
                return new LoginResponseDto { Message = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(user.UserName) is not null)
                return new LoginResponseDto { Message = "UserName is already registered!" };

            var appUser = _mapper.Map<SignUpDto, AppUser>(user);

            if (appUser is null)
            {
                Log.Error("Failed to map {Source} to {Destination} in {ServiceName}",
                    nameof(SignUpDto), nameof(AppUser), nameof(AccountServices));
                return null;
            }

            var createdUser = await _userManager.CreateAsync(appUser, user.Password);

            if (!createdUser.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in createdUser.Errors)
                    errors += $"{error.Description}, ";

                Log.Warning("Failed to create user {UserName}: {Errors}", appUser.UserName, errors.TrimEnd(',', ' '));

                return new LoginResponseDto { Message = errors };
            }

            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new IdentityRole("User"));

            await _userManager.AddToRoleAsync(appUser, "User");

            var jwtSecurityToken = await _authService.CreateJwtTokenAsync(appUser);

            var refreshToken = _authService.GenerateRefreshToken();

            if (appUser.RefreshTokens == null)
                appUser.RefreshTokens = new List<RefreshToken>();

            appUser.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(appUser);

            await transaction.CommitAsync();

            return new LoginResponseDto
            {
                UserId = appUser.Id,
                Email = user.Email,
                TokenExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiresOn = refreshToken.ExpiresOn
            };

        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Log.Error(ex, "Unexpected error while creating user in {ServiceName}", nameof(AccountServices));
        }

        return null;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(dto.Email ?? string.Empty);

            if (user is null)
                user = await _userManager.FindByNameAsync(dto.Email ?? string.Empty);

            if (user is null)
                user = await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == dto.Email);

            if (user is null)
            {
                Log.Warning($"Cant Found User With Email Or UserName: {dto.Email}");
                return null;
            }

            var isAuth = await _signInManager.CheckPasswordSignInAsync(user!, dto.Password!, true);
            if (!isAuth.Succeeded)
            {
                Log.Warning($"Password Is Not Correct For Account : {dto.Email}");
                return null;
            }

            var jwtSecurityToken = await _authService.CreateJwtTokenAsync(user!);

            if (jwtSecurityToken is null)
            {
                Log.Warning($"Cant Create Token For : {dto.Email}");
                return null;
            }

            RevokeAllRefreshTokens(user);

            var refreshToken = _authService.GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var loginResponse = new LoginResponseDto
            {
                UserId = user.Id,
                Email = user.Email!,
                TokenExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName!,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiresOn = refreshToken.ExpiresOn
            };
            return loginResponse;

        }
        catch (Exception ex)
        {
            Log.Error("Error During Login ", ex);
            return null;
        }
    }

    public void RevokeAllRefreshTokens(AppUser user)
    {
        if (user.RefreshTokens is null) return;

        foreach (var token in user.RefreshTokens.Where(t => t.IsActive))
            token.RevokedOn = DateTime.UtcNow;
    }

    public async Task<bool> LogoutAsync()
    {
        try
        {
            await _signInManager.SignOutAsync();

            var token = _httpContextAccessor.HttpContext!.Request.Headers["Authorization"]
                .FirstOrDefault()?
                .Split(" ")
                .Last();

            if (token != null)
            {
                try
                {
                    var userId = GetUserIdFromToken(token);

                    if (userId is not null)
                    {
                        var user = await _userManager.FindByIdAsync(userId!);
                        RevokeAllRefreshTokens(user!);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message); 
                    return false;
                }
            }

            return false;
        }
        catch (Exception ex)
        {
            Log.Error("Error During Logout ", ex);
            return false;
        }
    }

    private string? GetUserIdFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        return jwtToken.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
    }
}