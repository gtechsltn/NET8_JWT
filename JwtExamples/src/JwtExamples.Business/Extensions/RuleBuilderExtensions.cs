using FluentValidation;

namespace JwtExamples.Business.Extensions;

public static class RuleBuilderExtensions
{
    private const int NameMinLength = 2;
    private const int NameMaxLength = 40;
    private static readonly char[] AllowedNameCharacters = ['.', ',', '-', '—', '\'', ' '];

    public static IRuleBuilderOptions<T, string> FirstName<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder
            .NotEmpty()
            .Length(NameMinLength, NameMaxLength)
            .Must(x => x?.All(c => char.IsLetter(c) || AllowedNameCharacters.Contains(c)) ?? false)
            .WithMessage("The first name must only contain letters or the allowed special characters.");

    public static IRuleBuilderOptions<T, string> LastName<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder
            .NotEmpty()
            .Length(NameMinLength, NameMaxLength)
            .Must(x => x?.All(c => char.IsLetter(c) || AllowedNameCharacters.Contains(c)) ?? false)
            .WithMessage("The last name must only contain letters or the allowed special characters.");
}