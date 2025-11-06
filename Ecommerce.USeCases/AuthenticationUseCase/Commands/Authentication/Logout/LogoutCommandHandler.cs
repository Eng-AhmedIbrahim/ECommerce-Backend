namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
{
    private readonly IAccountServices _accountServices;
    public LogoutCommandHandler(IAccountServices accountServices)
    {
        _accountServices = accountServices;
    }
    public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        return await _accountServices.LogoutAsync();
    }
}
