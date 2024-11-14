using FluentResults;
using MediatR;

namespace JwtExamples.Business.Products.Delete;

public sealed record DeleteProductCommand(Guid Id) : IRequest<Result>;