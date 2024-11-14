using FluentResults;
using JwtExamples.Business.Shared;
using MediatR;

namespace JwtExamples.Business.Products.GetAll;

public sealed record GetAllProductsQuery : IRequest<List<ProductResponse>>;
