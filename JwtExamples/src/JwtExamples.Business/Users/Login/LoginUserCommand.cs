using FluentResults;
using MediatR;

namespace JwtExamples.Business.Users.Login;

public sealed record LoginUserCommand(string Email, string Password) : IRequest<Result<string>>;
