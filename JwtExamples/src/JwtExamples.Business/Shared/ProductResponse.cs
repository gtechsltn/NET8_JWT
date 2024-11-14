namespace JwtExamples.Business.Shared;

public sealed record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price);