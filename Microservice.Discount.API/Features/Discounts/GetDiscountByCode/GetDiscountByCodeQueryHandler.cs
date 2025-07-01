using Microservice.Discount.API.Repositories;
using Microservice.Shared.Services;

namespace Microservice.Discount.API.Features.Discounts.GetDiscountByCode;

public class GetDiscountByCodeQueryHandler(AppDbContext context, IIdentityService identityService) : IRequestHandler<GetDiscountByCodeQuery, ServiceResult<GetDiscountByCodeQueryResponse>>
{
    public async Task<ServiceResult<GetDiscountByCodeQueryResponse>> Handle(GetDiscountByCodeQuery request, CancellationToken cancellationToken)
    {
        var hasDiscount = await context.Discounts.SingleOrDefaultAsync(x => x.Code == request.Code, cancellationToken);

        if (hasDiscount == null)
        {
            return ServiceResult<GetDiscountByCodeQueryResponse>.Error($"No discount found for given Code",HttpStatusCode.NotFound);
        }

        if (hasDiscount.ExpiresAt < DateTime.UtcNow)
        {
            return ServiceResult<GetDiscountByCodeQueryResponse>.Error($"The code {request.Code} has expired",HttpStatusCode.BadRequest);
        }

        return ServiceResult<GetDiscountByCodeQueryResponse>.SuccessAsOk(
            new GetDiscountByCodeQueryResponse(hasDiscount.Code, hasDiscount.Rate));


    }
}