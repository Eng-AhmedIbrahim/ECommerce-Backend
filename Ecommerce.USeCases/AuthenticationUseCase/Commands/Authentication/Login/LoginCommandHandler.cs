namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto?>
{
    private readonly IAccountServices _accountServices;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IAccountServices accountServices,IMapper mapper)
    {
        _accountServices = accountServices;
        _mapper = mapper;
    }
    public async Task<LoginResponseDto?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var mappedLoginDto = _mapper.Map<LoginCommand, LoginDto>(request);

        var loginResponse = await _accountServices.LoginAsync(mappedLoginDto);
        if(loginResponse is null)
            return null;

        return loginResponse;

    }
}