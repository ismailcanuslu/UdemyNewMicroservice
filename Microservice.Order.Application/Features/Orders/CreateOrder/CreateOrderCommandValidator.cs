using FluentValidation;

namespace Microservice.Order.Application.Features.Orders.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.DiscountRate)
            .GreaterThanOrEqualTo(0).When(x => x.DiscountRate.HasValue)
            .WithMessage("{PropertyName} must be greater than zero")
            .GreaterThanOrEqualTo(100)
            .WithMessage("{PropertyName} must be between 0 and 100.");

        RuleFor(x => x.Address)
            .SetValidator(new AddressDtoValidator());

        RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("At least one order item is required.");

        RuleForEach(x => x.Items)
            .SetValidator(new OrderItemDtoValidator());

        RuleFor(x => x.Payment)
            .SetValidator(new PaymentDtoValidator());
    }

    private class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.Province)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.District)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Matches(@"^\d{5}$")
                .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Line)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
        }
    }

    public class PaymentDtoValidator : AbstractValidator<PaymentDto>
    {
        public PaymentDtoValidator()
        {
            RuleFor(x => x.CardNumber)
                .NotEmpty()
                .WithMessage("Card number is required.")
                .CreditCard()
                .WithMessage("Card number is not valid.");

            RuleFor(x => x.CardHolderName)
                .NotEmpty()
                .WithMessage("Card holder name is required.");

            RuleFor(x => x.Expiration)
                .NotEmpty()
                .WithMessage("Expiration date is required.")
                .Matches(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$")
                .WithMessage("Expiration date format should be MM/YY or MM/YYYY.");

            RuleFor(x => x.CvvCode)
                .NotEmpty()
                .WithMessage("CVV code is required.")
                .Length(3, 4)
                .WithMessage("CVV code must be 3 or 4 digits.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Payment amount must be greater than zero.");
        }
    }


    // Nested OrderItemDto Validator
    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Product ID is required.");

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Product name is required.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Unit price must be greater than zero.");
        }
    }
}