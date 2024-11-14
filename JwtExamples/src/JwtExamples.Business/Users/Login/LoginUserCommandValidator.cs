using FluentValidation;

namespace JwtExamples.Business.Users.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Password is required.");
    }
}