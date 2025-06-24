using FluentValidation;

namespace Microservice.Catalog.API.Features.Courses.Update;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(4,100).WithMessage("{PropertyName} must be between 4 and 100 characters.");
        
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(4,1000).WithMessage("{PropertyName} must have between 4 and 1000 characters.");
        
        RuleFor(c => c.Price)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

        RuleFor(c => c.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}