using FluentResults;

namespace JwtExamples.Business.Errors;

/// <summary>
/// Represents the error.
/// </summary>
/// <param name="Code">The error code.</param>
/// <param name="Description">The error description.</param>
public static class Errors
{
    #region Products

    public static Error UserNotFound => new("Product not found");

    public static Error EmailAlreadyTaken => new("Product bad request");

    public static Error IncorrectPassword => new("Incorrect password");
    
    #endregion

    #region Products

    public static Error ProductNotFound => new("Product not found");

    public static Error ProductBadRequest => new("Product bad request");

    #endregion
}