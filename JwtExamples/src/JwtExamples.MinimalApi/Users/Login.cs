using JwtExamples.Business.Users.Login;
using JwtExamples.MinimalApi.Abstractions;
using JwtExamples.MinimalApi.Constants;
using Mapster;
using MediatR;

namespace JwtExamples.MinimalApi.Users;

public sealed record LoginRequest(string Email, string Password);

public sealed class LoginEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/login", async (ISender sender, LoginRequest request, CancellationToken cancellationToken) =>
        {
            var command = request.Adapt<LoginUserCommand>();

            var response = await sender.Send(command, cancellationToken);

            return Results.Ok(response);
        }).WithTags(Tags.Users);
    }
}