using JwtExamples.Business.Products.Delete;
using JwtExamples.MinimalApi.Abstractions;
using JwtExamples.MinimalApi.Constants;
using MediatR;
namespace JwtExamples.MinimalApi.Products;

public sealed class DeleteEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("products/{id:guid}", async (ISender sender, Guid id, CancellationToken cancellationToken) =>
        {
            var command = new DeleteProductCommand(id);

            await sender.Send(command, cancellationToken);

            return Results.NoContent();
        })
        .WithTags(Tags.Products)
        .RequireAuthorization();
    }
}