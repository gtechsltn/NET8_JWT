using JwtExamples.Business.Users.GetById;
using JwtExamples.Infrastructure.Extensions;
using JwtExamples.MinimalApi.Abstractions;
using JwtExamples.MinimalApi.Constants;
using MediatR;

namespace JwtExamples.MinimalApi.Users;

internal sealed class MeEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/", async (ISender sender, HttpContext context, CancellationToken cancellationToken) =>
            {
                var query = new GetUserByIdQuery(context.User.GetUserId());

                var response = await sender.Send(query, cancellationToken);

                return Results.Ok(response);
            })
            .WithTags(Tags.Users)
            .RequireAuthorization();
    }
}