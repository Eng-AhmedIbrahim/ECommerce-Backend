namespace Ecommerce.UseCases.AuthenticationUseCase.Commands.Authentication.CreateUser;

public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidation()
    {
        RuleFor(r => r.FullName)
               .NotNull().WithMessage("Full name is required")
               .NotEmpty().WithMessage("Full name cannot be empty")
               .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters");

        RuleFor(r => r.UserName)
              .NotNull().WithMessage("Username is required")
              .NotEmpty().WithMessage("Username cannot be empty")
              .MinimumLength(3).WithMessage("Username must be at least 3 characters")
              .MaximumLength(50).WithMessage("Username cannot exceed 50 characters");

        RuleFor(r => r.Email)
               .NotNull().WithMessage("Email is required")
               .NotEmpty().WithMessage("Email cannot be empty")
               .EmailAddress().WithMessage("Invalid email format");

        RuleFor(r => r.HasAcceptedTerms)
               .Equal(true).WithMessage("You must accept the terms and conditions");

        RuleFor(r => r.PhoneNumber)
                .NotNull().WithMessage("Phone number is required")
                .NotEmpty().WithMessage("Phone number cannot be empty")
                .Length(11).WithMessage("Phone number must be 11 digits")
                .Matches("^[0-9]+$").WithMessage("Phone number must contain only digits");

        RuleFor(r => r.Password)
                 .NotNull().WithMessage("Password is required")
                 .NotEmpty().WithMessage("Password cannot be empty")
                 .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                 .MaximumLength(50).WithMessage("Password cannot exceed 50 characters")
                 .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                 .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                 .Matches("[0-9]").WithMessage("Password must contain at least one number")
                 .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");
    }
}