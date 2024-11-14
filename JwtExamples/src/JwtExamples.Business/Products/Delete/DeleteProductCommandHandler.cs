using FluentResults;
using JwtExamples.Business.Abstractions.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static JwtExamples.Business.Errors.Errors;

namespace JwtExamples.Business.Products.Delete;

internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteProductCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return Result.Fail(UserNotFound);
        }

        _dbContext.Products.Remove(product);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}