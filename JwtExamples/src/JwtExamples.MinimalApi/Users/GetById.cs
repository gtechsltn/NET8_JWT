using JwtExamples.Business.Users.GetById;
using JwtExamples.MinimalApi.Abstractions;
using JwtExamples.MinimalApi.Constants;
using MediatR;

namespace JwtExamples.MinimalApi.Users;

internal sealed class GetByIdEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{userId}", async (ISender sender, Guid userId, CancellationToken cancellationToken) =>
            {
                var query = new GetUserByIdQuery(userId);

                var response = await sender.Send(query, cancellationToken);

                return Results.Ok(response);
            })
            .WithTags(Tags.Users)
            .RequireAuthorization();
    }
}