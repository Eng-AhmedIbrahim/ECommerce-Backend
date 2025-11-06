namespace Ecommerce.Infrastructure.Services.Authentication;

public static class CreateUserFromSocialLoginExtensionService
{
    public static async Task<LoginResponseDto> CreateUserFromSocialLogin(
        this UserManager<AppUser> userManager,
        AppDbContext context,
        CreateUserFromSocialLogin model,
        LoginProvider loginProvider,
        IAuthenticationService authenticationService)
    {
        var user = await userManager.FindByLoginAsync(loginProvider.GetDisplayName(),
            model.LoginProviderSubject);

        if (user != null)
            return await GenerateLoginResponseAsync(authenticationService, userManager, user);

        user = await userManager.FindByEmailAsync(model.Email);

        if (user is null)
        {
            var userName = IsUsernameLatinChars(model.UserName)
                ? model?.UserName
                : model.Email.Split('@').First();

            user = new AppUser
            {
                Email = model?.Email,
                UserName = userName,
                ProfilePictureUrl = model?.ProfilePicture ?? string.Empty,
            };

            await userManager.CreateAsync(user);
            await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
        }

        var userLoginInfo = new UserLoginInfo(
            loginProvider.GetDisplayName(),
            model?.LoginProviderSubject!,
            loginProvider.GetDisplayName().ToUpper());

        var result = await userManager.AddLoginAsync(user, userLoginInfo);
        if (!result.Succeeded)
            throw new Exception("Failed to add login for user");

        return await GenerateLoginResponseAsync(authenticationService, userManager, user);
    }

    private static async Task<LoginResponseDto> GenerateLoginResponseAsync(
        IAuthenticationService authenticationService,
        UserManager<AppUser> userManager,
        AppUser user)
    {
        var token = await authenticationService.CreateJwtTokenAsync(user);
        var refreshToken = authenticationService.GenerateRefreshToken();
        user.RefreshTokens ??= new List<RefreshToken>();
        user.RefreshTokens.Add(refreshToken);
        await userManager.UpdateAsync(user);

        var handler = new JwtSecurityTokenHandler();
        var roles = await userManager.GetRolesAsync(user);

        return new LoginResponseDto
        {
            IsAuthenticated = true,
            Token = handler.WriteToken(token),
            TokenExpiresOn = token.ValidTo.ToLocalTime(),
            RefreshToken = refreshToken.Token,
            RefreshTokenExpiresOn = refreshToken.ExpiresOn.ToLocalTime(),
            UserName = user.UserName!,
            Email = user.Email!,
            UserId = user.Id,
            Roles = roles.ToList(),
        };
    }

    private static bool IsUsernameLatinChars(string username)
    {
        var regex = @"^[a-zA-Z]+$";
        return Regex.IsMatch(username, regex);
    }

}