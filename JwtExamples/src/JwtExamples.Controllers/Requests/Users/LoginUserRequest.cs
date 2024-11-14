namespace JwtExamples.ControllerApi.Requests.Users;

public sealed record LoginUserRequest(
    string Email,
    string Password);