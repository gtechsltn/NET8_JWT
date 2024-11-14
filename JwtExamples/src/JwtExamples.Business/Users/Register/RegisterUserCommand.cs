using FluentResults;
using MediatR;

namespace JwtExamples.Business.Users.Register;

public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName) : IRequest<Result<Guid>>;