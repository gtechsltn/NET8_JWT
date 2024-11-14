using JwtExamples.Business.Abstractions.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JwtExamples.Business.Users.GetById;

internal sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse?>
{
    private readonly IApplicationDbContext _dbContext;

    public GetUserByIdQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<UserResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
        await _dbContext.Users
            .Where(x => x.Id == request.Id)
            .Select(x => new UserResponse(
                x.Id,
                x.Email,
                x.FirstName,
                x.LastName,
                x.CreatedAt))
            .FirstOrDefaultAsync(cancellationToken);
}