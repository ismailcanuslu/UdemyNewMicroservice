using FluentValidation;

namespace Microservice.Payment.API.Features.Payments.Create;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        
        RuleFor(x => x.OrderCode)
            .NotEmpty().WithMessage("Order code is required.")
            .Length(6, 20).WithMessage("Order code must be between 6 and 20 characters.");

        RuleFor(x => x.CardNumber)
            .CreditCard().WithMessage("Invalid card number.")
            .NotEmpty().WithMessage("Card number is required.");

        RuleFor(x => x.CardHolderName)
            .NotEmpty().WithMessage("Cardholder name is required.")
            .MaximumLength(50).WithMessage("Cardholder name must not exceed 50 characters.");

        RuleFor(x => x.CardExpirationDate)
            .NotEmpty().WithMessage("Card expiration date is required.")
            .Matches(@"^(0[1-9]|1[0-2])/\d{2}$").WithMessage("Card expiration date must be in MM/YY format.");

        RuleFor(x => x.CardSecurityNumber)
            .NotEmpty().WithMessage("Card security number is required.")
            .Length(3, 4).WithMessage("Card security number must be 3 or 4 digits.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0.");
    }
}