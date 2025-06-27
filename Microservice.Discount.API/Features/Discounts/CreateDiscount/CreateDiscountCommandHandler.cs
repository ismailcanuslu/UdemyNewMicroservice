using Microservice.Discount.API.Repositories;
using Microservice.Shared.Services;

namespace Microservice.Discount.API.Features.Discounts.CreateDiscount;

public class CreateDiscountCommandHandler(AppDbContext context, IIdentityService identityService) : IRequestHandler<CreateDiscountCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var hasCodeGotUser = await context.Discounts.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Code == request.Code, cancellationToken);

        if (hasCodeGotUser is not null)
        {
            return ServiceResult.Error("Discount code already exists for this user",HttpStatusCode.BadRequest);
        }
        
        var discount = new Discount()
        {
            Id = NewId.NextSequentialGuid(),
            Code = request.Code,
            CreatedDateTime = DateTime.Now,
            Rate = request.Rate,
            ExpiresAt = request.ExpiresAt,
            UserId = request.UserId
        };
        
        await context.Discounts.AddAsync(discount, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}