namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, LoginResponseDto?>
{
    private readonly IAccountServices _accountServices;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authService;

    public CreateUserCommandHandler(
        IAccountServices accountServices,
        IMapper mapper,
        IAuthenticationService authService)
    {
        _accountServices = accountServices;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<LoginResponseDto?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var mappedUser = _mapper.Map<CreateUserCommand, SignUpDto>(request);

        var createdUser = await _accountServices.RegisterAsync(mappedUser);

        if (createdUser is null)
            return null;

        return createdUser;
    }
}