using FluentValidation;
using JwtExamples.Business.Extensions;

namespace JwtExamples.Business.Users.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(user => user.FirstName).FirstName();

        RuleFor(user => user.LastName).LastName();

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Password is required.");
    }
}