using FluentValidation;

namespace Microservice.Basket.API.Features.Baskets.ApplyDiscountCoupon;

public class ApplyDiscountCouponValidator : AbstractValidator<ApplyDiscountCouponCommand>
{
    public ApplyDiscountCouponValidator()
    {
        RuleFor(x => x.Coupon).NotEmpty()
            .WithMessage("{PropertyName} is required");
        RuleFor(x => x.DiscountRate)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
    }
}