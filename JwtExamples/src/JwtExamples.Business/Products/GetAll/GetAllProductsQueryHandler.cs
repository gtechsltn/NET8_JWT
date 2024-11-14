using FluentResults;
using JwtExamples.Business.Abstractions.Data;
using JwtExamples.Business.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JwtExamples.Business.Products.GetAll;

internal sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IApplicationDbContext _dbContext;

    public GetAllProductsQueryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<List<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var response = await _dbContext.Products
            .Select(x => new ProductResponse(
                x.Id,
                x.Name,
                x.Description,
                x.Price))
            .ToListAsync(cancellationToken);

        return response;
    }
}