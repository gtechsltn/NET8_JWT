using FluentResults;
using JwtExamples.Business.Abstractions.Authentication;
using JwtExamples.Business.Abstractions.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static JwtExamples.Business.Errors.Errors;

namespace JwtExamples.Business.Users.Login;

internal sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<string>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtGenerator _jwtGenerator;

    public LoginUserCommandHandler(
        IApplicationDbContext dbContext,
        IPasswordHasher passwordHasher,
        IJwtGenerator jwtGenerator)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Fail(UserNotFound);
        }

        if (!_passwordHasher.Verify(request.Password, user.Password))
        {
            return Result.Fail(IncorrectPassword);
        }

        return Result.Ok(_jwtGenerator.Generate(user.Id, user.Email));
    }
}