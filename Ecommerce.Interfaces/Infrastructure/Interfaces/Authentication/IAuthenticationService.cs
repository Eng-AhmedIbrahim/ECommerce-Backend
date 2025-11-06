using System.IdentityModel.Tokens.Jwt;

namespace Ecommerce.Interfaces.Infrastructure.Interfaces.Authentication;

public interface IAuthenticationService
{
    public Task<JwtSecurityToken> CreateJwtTokenAsync(AppUser user);
    public Task<LoginResponseDto> RefreshTokenAsync(string refreshToken);
    public Task<bool> RevokeJwtTokenAsync(string refreshToken);
    public RefreshToken GenerateRefreshToken();
}