using Microservice.Payment.API.Repositories;

namespace Microservice.Payment.API.Features.Payments.GetAllPaymentsByUserId;

public record GetAllPaymentsByUserIdResponse(
    Guid Id,
    string OrderCode,
    string Amount,
    DateTime Created,
    PaymentStatus Status);
