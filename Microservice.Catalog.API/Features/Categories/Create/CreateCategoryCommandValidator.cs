using FluentValidation;

namespace Microservice.Catalog.API.Features.Categories.Create;

public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(4,25).WithMessage("{PropertyName} must be between 4 and 25 characters.");
    }
}