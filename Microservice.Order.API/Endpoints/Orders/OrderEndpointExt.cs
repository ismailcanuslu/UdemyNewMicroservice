using Asp.Versioning.Builder;

namespace Microservice.Order.API.Endpoints.Orders;

public static class OrderEndpointExt
{
    public static void AddOrderGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("/api/v{version:apiVersion}/orders")
            .WithApiVersionSet(apiVersionSet)
            .CreateOrderGroupItemEndpoint()
            .GetOrdersGroupItemEndpoint()
            .MapToApiVersion(1,0)
            .WithTags("Orders");
    }
}