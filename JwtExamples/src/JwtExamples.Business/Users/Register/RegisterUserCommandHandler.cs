using FluentResults;
using JwtExamples.Business.Abstractions.Authentication;
using JwtExamples.Business.Abstractions.Data;
using JwtExamples.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static JwtExamples.Business.Errors.Errors;

namespace JwtExamples.Business.Users.Register;

internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(IApplicationDbContext dbContext, IPasswordHasher passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var exists = await _dbContext.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (exists)
        {
            return Result.Fail(EmailAlreadyTaken);
        }

        var hashedPassword = _passwordHasher.Hash(request.Password);

        var user = new User(
            Guid.NewGuid(),
            request.Email,
            hashedPassword,
            request.FirstName,
            request.LastName,
            DateTime.UtcNow);

        _dbContext.Users.Add(user);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}