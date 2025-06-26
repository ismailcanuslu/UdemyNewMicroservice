using FluentValidation;

namespace Microservice.Basket.API.Features.Baskets.DeleteBasketItem;

public class DeleteBasketItemCommandValidator : AbstractValidator<DeleteBasketItemCommand>
{
    public DeleteBasketItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("CourseId is required");
    }
}