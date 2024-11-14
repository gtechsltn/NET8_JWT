using JwtExamples.Business.Shared;
using JwtExamples.Business.Users.GetById;
using JwtExamples.Business.Users.Login;
using JwtExamples.Business.Users.Register;
using JwtExamples.ControllerApi.Abstractions;
using JwtExamples.ControllerApi.Requests.Users;
using JwtExamples.Infrastructure.Extensions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtExamples.ControllerApi.Controllers;

// Or you can place [Authorize] on controller level and for unprotected endpoint use [AllowAnonymous] attribute 
[Route("api/[controller]")]
public sealed class UsersController : BaseController
{
    /// <summary>
    /// Register new user.
    /// </summary>
    /// <param name="request">The create user request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The user identifier.</returns>
    [HttpPost("register")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Register(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<RegisterUserCommand>();

        var response = await Sender.Send(command, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Get user by specified identifier.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The user details with the specified identifier.</returns>
    [HttpGet("{userId:guid}")]
    [Authorize]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetById(Guid userId, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(userId);

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Gets user details for logged user.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>User details.</returns>
    [HttpGet("me")]
    [Authorize]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetLoggedUser(CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(HttpContext.User.GetUserId());

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Register new user.
    /// </summary>
    /// <param name="request">The create user request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The user identifier.</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Login(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<LoginUserCommand>();

        var response = await Sender.Send(command, cancellationToken);

        return Ok(response);
    }
}