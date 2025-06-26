using System.Net;
using System.Text.Json;
using MediatR;
using Microservice.Basket.API.Dto;
using Microservice.Shared;

namespace Microservice.Basket.API.Features.Baskets.ApplyDiscountCoupon;

public class ApplyDiscountCouponCommandHandler(BasketService basketService)
    : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
    {
        var basketAsJson = await basketService.GetBasketFromCacheAsync(cancellationToken);
        
        if (string.IsNullOrEmpty(basketAsJson))
        {
            return ServiceResult<BasketDto>.Error("Basket not found",HttpStatusCode.NotFound);
        }

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

        if (!basket!.Items.Any())
        {
            return ServiceResult<BasketDto>.Error("Basket item not found",HttpStatusCode.NotFound);
        }
        
        basket.ApplyNewDiscount(request.Coupon,request.DiscountRate);
        
        basketAsJson = JsonSerializer.Serialize(basket);
        await basketService.CreateBasketCacheAsync(basket,cancellationToken);

        return ServiceResult.SuccessAsNoContent();

    }
}