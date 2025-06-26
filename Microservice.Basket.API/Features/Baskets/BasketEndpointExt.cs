using Asp.Versioning.Builder;
using Microservice.Basket.API.Features.Baskets.AddBasketItem;
using Microservice.Basket.API.Features.Baskets.ApplyDiscountCoupon;
using Microservice.Basket.API.Features.Baskets.DeleteBasketItem;
using Microservice.Basket.API.Features.Baskets.GetBasket;
using Microservice.Basket.API.Features.Baskets.RemoveDiscountCoupon;

namespace Microservice.Basket.API.Features.Baskets;

public static class BasketEndpointExt
{
   public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
   {
      app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
         .WithApiVersionSet(apiVersionSet)
         .AddBasketItemGroupItemEndpoint()
         .DeleteBasketItemGroupEndpoint()
         .GetBasketQueryGroupEndpoint()
         .ApplyDiscountCouponItemGroupEndpoint()
         .RemoveDiscountCouponGroupEndpoint()
         ;
   }
}