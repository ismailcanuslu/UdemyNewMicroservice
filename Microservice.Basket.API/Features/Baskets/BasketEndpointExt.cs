using Asp.Versioning.Builder;
using Microservice.Basket.API.Features.Baskets.AddBasketItem;

namespace Microservice.Basket.API.Features.Baskets;

public static class BasketEndpointExt
{
   public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
   {
      app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
         .WithApiVersionSet(apiVersionSet)
         .AddBasketItemGroupItemEndpoint();
   }
}