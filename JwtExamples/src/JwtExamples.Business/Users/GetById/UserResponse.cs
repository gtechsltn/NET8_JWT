namespace JwtExamples.Business.Users.GetById;

public sealed record UserResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    DateTime CreatedAt);