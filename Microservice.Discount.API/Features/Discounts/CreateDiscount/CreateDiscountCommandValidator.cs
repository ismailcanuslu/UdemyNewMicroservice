using FluentValidation;

namespace Microservice.Discount.API.Features.Discounts.CreateDiscount;

public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
{
    public CreateDiscountCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(10).WithMessage("{PropertyName} must be 10 characters long.");
        RuleFor(x => x.Rate).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.ExpiresAt).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}