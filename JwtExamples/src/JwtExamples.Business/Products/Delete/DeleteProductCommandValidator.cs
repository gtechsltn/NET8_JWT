using FluentValidation;

namespace JwtExamples.Business.Products.Delete;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product Id must be at most 100 characters.");
    }
}