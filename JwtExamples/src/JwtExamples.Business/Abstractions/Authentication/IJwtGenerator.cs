namespace JwtExamples.Business.Abstractions.Authentication;

public interface IJwtGenerator
{
    string Generate(Guid id, string email);
}