using Microservice.Discount.API.Features.Discounts.CreateDiscount;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Discount.API.Features.Discounts.GetDiscountByCode;

public static class GetDiscountByCodeQueryEndpoint
{
    public static RouteGroupBuilder GetDiscountByCodeQueryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{code:length(10)}", async (string code, IMediator mediator) =>
                (await mediator.Send(new GetDiscountByCodeQuery(code))).ToGenericResult())
            .Produces<GetDiscountByCodeQueryResponse>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .MapToApiVersion(1,0)
            .WithName("GetDiscountByCode");

        return group;
    }
}