using FluentResults;
using MediatR;

namespace JwtExamples.Business.Products.Create;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    decimal Price) : IRequest<Result<Guid>>;