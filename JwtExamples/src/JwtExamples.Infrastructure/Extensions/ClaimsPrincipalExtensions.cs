using System.Security.Claims;

namespace JwtExamples.Infrastructure.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal) => Guid.Parse(
        principal.Claims
            .SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?
            .Value);
}