using Microservice.Payment.API.Repositories;
using Microservice.Shared;

namespace Microservice.Payment.API.Features.Payments.GetAllPaymentsByUserId;

public record GetAllPaymentsByUserIdQuery : IRequestByServiceResult<List<GetAllPaymentsByUserIdResponse>>;
