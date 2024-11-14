using JwtExamples.Business.Shared;
using MediatR;

namespace JwtExamples.Business.Products.GetById;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<ProductResponse?>;
