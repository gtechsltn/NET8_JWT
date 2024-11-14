using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JwtExamples.ControllerApi.Abstractions;

/// <summary>
/// Represents the base API controller.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    private ISender _sender;

    /// <summary>
    /// Gets the sender.
    /// </summary>
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
}