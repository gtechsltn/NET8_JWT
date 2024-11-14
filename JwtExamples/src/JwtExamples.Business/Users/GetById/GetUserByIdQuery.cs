using FluentResults;
using MediatR;

namespace JwtExamples.Business.Users.GetById;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserResponse?>;