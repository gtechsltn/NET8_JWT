using FluentResults;
using FluentValidation;
using MediatR;

namespace JwtExamples.Business.Behaviors;

/// <summary>
/// Represents the validation behavior middleware.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
        _validators = validators;

    public async Task<TResponse?> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errors = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => new Error(x.ErrorMessage))
            .ToList();

        if (!errors.Any())
        {
            return await next();
        }

        var resultType = typeof(TResponse);

        if (resultType == typeof(Result))
        {
            var result = new Result();

            result.WithErrors(errors);

            return (TResponse)(object)result;
        }
        if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(Result<>))
        {
            var resultGenericType = resultType.GetGenericArguments().First();
            var resultTypeInstance = typeof(Result<>).MakeGenericType(resultGenericType);
            var result = Activator.CreateInstance(resultTypeInstance);

            var withErrorsMethod = resultTypeInstance.GetMethod("WithErrors", [typeof(IEnumerable<IError>)]);

            withErrorsMethod?.Invoke(result, [errors]);

            return (TResponse)result!;
        }

        throw new InvalidOperationException($"Unsupported result type: {resultType.FullName}");
    }
}