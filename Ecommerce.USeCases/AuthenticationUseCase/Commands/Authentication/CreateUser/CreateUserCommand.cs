namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.CreateUser;
public record CreateUserCommand(
    string? FullName,
    string?UserName,
    string?Email,
    string?PhoneNumber,
    DateTime DateOfBirth,
    bool HasAcceptedTerms,
    string? Password
     ) : IRequest<LoginResponseDto?>
{
    public IFormFile? ProfilePicture { get; set; }
}