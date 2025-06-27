using Asp.Versioning.Builder;
using Microservice.Discount.API.Features.Discounts.CreateDiscount;
using Microservice.Discount.API.Features.Discounts.GetDiscountByCode;

namespace Microservice.Discount.API.Features.Discounts;

public static class DiscountEndpointExt
{
    public static void AddDiscountGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("/api/v{version:apiVersion}/discounts")
            .WithApiVersionSet(apiVersionSet)
            .CreateDiscountCommandGroupItemEndpoint()
            .GetDiscountByCodeQueryGroupItemEndpoint()
            .MapToApiVersion(1,0)
            .WithTags("Discounts");
    }
}