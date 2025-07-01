using Asp.Versioning.Builder;
using Microservice.Payment.API.Features.Payments.Create;
using Microservice.Payment.API.Features.Payments.GetAllPaymentsByUserId;

namespace Microservice.Payment.API.Features.Payments;

public static class PaymentEndpointExt
{
    public static void AddPaymentGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("/api/v{version:apiVersion}/payments")
            .WithApiVersionSet(apiVersionSet)
            .CreatePaymentCommandGroupItemEndpoint()
            .GetAllPaymentsCommandGroupItemEndpoint()
            .MapToApiVersion(1,0)
            .WithTags("Payments");
    }
}