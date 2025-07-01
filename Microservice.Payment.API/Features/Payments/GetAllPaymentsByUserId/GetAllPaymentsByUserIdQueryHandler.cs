using MediatR;
using Microservice.Payment.API.Repositories;
using Microservice.Shared;
using Microservice.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Payment.API.Features.Payments.GetAllPaymentsByUserId;

public class GetAllPaymentsByUserIdQueryHandler(AppDbContext context, IIdentityService identityService) : IRequestHandler<GetAllPaymentsByUserIdQuery, ServiceResult<List<GetAllPaymentsByUserIdResponse>>>
{
    public async Task<ServiceResult<List<GetAllPaymentsByUserIdResponse>>> Handle(GetAllPaymentsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userId = identityService.GetUserId;

        var payments = await context.Payments
            .Where(x => x.UserId == userId)
            .Select(x => new GetAllPaymentsByUserIdResponse(
                x.Id,
                x.OrderCode,
                x.Amount.ToString("C"),
                x.CreatedDateTime,
                x.Status
                )).ToListAsync(cancellationToken);

        return ServiceResult<List<GetAllPaymentsByUserIdResponse>>.SuccessAsOk(payments);
    }
}