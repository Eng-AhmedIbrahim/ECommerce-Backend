namespace Ecommerce.Infrastructure.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IOptions<JWTSettings> _jwt;
    private readonly UserManager<AppUser> _userManager;

    public AuthenticationService(IOptions<JWTSettings> Jwt, UserManager<AppUser> userManager)
    {
        _jwt = Jwt;
        _userManager = userManager;
    }

    public async Task<LoginResponseDto> RefreshTokenAsync(string refreshToken)
    {
        var loginResponse = new LoginResponseDto();
        var user = await _userManager.Users
            .Include(r=>r.RefreshTokens)
            .SingleOrDefaultAsync
            (u => u.RefreshTokens!.Any(t => t.Token == refreshToken));

        if (user is null)
        {
            loginResponse.Message = "Invalid token";
            return loginResponse;
        }

        var existingRefreshToken = user.RefreshTokens!.Single(t => t.Token == refreshToken);

        if (!existingRefreshToken!.IsActive)
        {
            loginResponse.Message = "Inactive token";
            return loginResponse;
        }

        existingRefreshToken.RevokedOn = DateTime.UtcNow;

        var newRefreshToken = GenerateRefreshToken();
        user.RefreshTokens!.Add(newRefreshToken);
        await _userManager.UpdateAsync(user);

        var jwtToken = await CreateJwtTokenAsync(user);
        loginResponse.IsAuthenticated = true;
        loginResponse.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        loginResponse.TokenExpiresOn = jwtToken.ValidTo.ToLocalTime();
        loginResponse.Email = user.Email!;
        loginResponse.UserName = user.UserName!;
        var roles = await _userManager.GetRolesAsync(user);
        loginResponse.Roles = roles.ToList();
        loginResponse.RefreshToken = newRefreshToken.Token;
        loginResponse.RefreshTokenExpiresOn = newRefreshToken.ExpiresOn.ToLocalTime();
        loginResponse.UserId = user.Id;
        return loginResponse;
    }

    public async Task<bool> RevokeJwtTokenAsync(string refreshToken)
    {
        var user = await _userManager.Users
            .SingleOrDefaultAsync(u => u.RefreshTokens!.Any(t => t.Token == refreshToken));

        if (user is null) return false;

        var existingRefreshToken = user?.RefreshTokens!.Single(t => t.Token == refreshToken);
        if (!existingRefreshToken!.IsActive)
            return false;

        existingRefreshToken.RevokedOn = DateTime.UtcNow;
        await _userManager.UpdateAsync(user!);

        return true;
    }

    public RefreshToken GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(randomNumber);

        return new RefreshToken
        {
            Token = Convert.ToBase64String(randomNumber),
            ExpiresOn = DateTime.UtcNow.AddDays(_jwt.Value.RefreshTokenDurationInDays),
            CreatedOn = DateTime.UtcNow
        };
    }

    public async Task<JwtSecurityToken> CreateJwtTokenAsync(AppUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
            roleClaims.Add(new Claim("roles", role));

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Value.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwt.Value.Issuer,
               audience: _jwt.Value.Audience,
               claims: claims,
               expires: DateTime.UtcNow.AddHours(_jwt.Value.DurationInHours),
               signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}