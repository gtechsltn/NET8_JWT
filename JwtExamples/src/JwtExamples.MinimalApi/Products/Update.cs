using JwtExamples.Business.Products.Update;
using JwtExamples.MinimalApi.Abstractions;
using JwtExamples.MinimalApi.Constants;
using Mapster;
using MediatR;

namespace JwtExamples.MinimalApi.Products;

public sealed class UpdateEndpoint : IEndpoint
{
    public sealed record UpdateRequest(string Name, string Description, decimal Price);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("products/{id:guid}", async (ISender sender, Guid id, UpdateRequest request, CancellationToken cancellationToken) =>
        {
            var command = request.Adapt<UpdateProductCommand>() with { Id = id };

            await sender.Send(command, cancellationToken);

            return Results.NoContent();
        })
        .WithTags(Tags.Products)
        .RequireAuthorization();
    }
}