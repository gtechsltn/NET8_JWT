using FluentResults;
using JwtExamples.Business.Abstractions.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static JwtExamples.Business.Errors.Errors;

namespace JwtExamples.Business.Products.Update;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateProductCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return Result.Fail(ProductNotFound);
        }

        product.Update(request.Name, request.Description, request.Price);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}