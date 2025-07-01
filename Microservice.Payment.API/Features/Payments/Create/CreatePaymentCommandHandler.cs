using System.Net;
using MediatR;
using Microservice.Payment.API.Repositories;
using Microservice.Shared;
using Microservice.Shared.Services;

namespace Microservice.Payment.API.Features.Payments.Create;

public class CreatePaymentCommandHandler(AppDbContext context, IIdentityService identityService) : IRequestHandler<CreatePaymentCommand, ServiceResult<Guid>>
{
    public async Task<ServiceResult<Guid>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var (isSuccess, error) = await ExternalPaymentProcessAsync(request.CardNumber, request.CardHolderName,
            request.CardExpirationDate, request.CardSecurityNumber, request.Amount);

        if (!isSuccess)
        {
            return ServiceResult<Guid>.Error("Payment Failed", "errorMessage", HttpStatusCode.BadRequest);
        }

        var userId = identityService.GetUserId;
        var newPayment = new Repositories.Payment(userId, request.OrderCode, request.Amount);
        newPayment.SetStatus(Repositories.PaymentStatus.Success);
        
        context.Payments.Add(newPayment);
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult<Guid>.SuccessAsOk(newPayment.Id);
    }

    private async Task<(bool isSuccess,string? error)> ExternalPaymentProcessAsync(string cardNumber, string cardHolderName,
        string cardExpirationDate, string cardSecurityNumber, decimal amount)
    {
        // dışarıdaki ödemeyi simüle et
        await Task.Delay(2000);
        return (true, null);
        
        // dışarıdaki ödeme başarısız simülasyonu
        //return (false,"Payment failed due to insufficient funds."); 
    }
}