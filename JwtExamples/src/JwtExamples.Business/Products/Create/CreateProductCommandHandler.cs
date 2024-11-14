using FluentResults;
using JwtExamples.Business.Abstractions.Data;
using JwtExamples.Domain;
using MediatR;

namespace JwtExamples.Business.Products.Create;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateProductCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            Guid.NewGuid(),
            DateTime.UtcNow,
            request.Name,
            request.Description,
            request.Price);

        _dbContext.Products.Add(product);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok(product.Id);
    }
}