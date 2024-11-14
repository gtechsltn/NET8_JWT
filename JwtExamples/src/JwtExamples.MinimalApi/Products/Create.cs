using JwtExamples.Business.Products.Create;
using JwtExamples.MinimalApi.Abstractions;
using JwtExamples.MinimalApi.Constants;
using Mapster;
using MediatR;

namespace JwtExamples.MinimalApi.Products;

public sealed record CreateRequest(string Name, string Description, decimal Price);

public sealed class CreateEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("products/", async (ISender sender, CreateRequest request, CancellationToken cancellationToken) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            var response = await sender.Send(command, cancellationToken);

            return Results.Ok(response.Value);
        })
        .WithTags(Tags.Products)
        .RequireAuthorization();
    }
}