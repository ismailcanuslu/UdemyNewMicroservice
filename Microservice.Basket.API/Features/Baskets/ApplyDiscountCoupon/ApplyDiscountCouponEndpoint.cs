using MediatR;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Basket.API.Features.Baskets.ApplyDiscountCoupon;

public static class ApplyDiscountCouponEndpoint
{
    public static RouteGroupBuilder ApplyDiscountCouponItemGroupEndpoint(this RouteGroupBuilder group)
    {
        group.MapPut("apply-discount-coupon", async (ApplyDiscountCouponCommand command, IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommand>>()
            .MapToApiVersion(1,0)
            .WithName("ApplyBasketDiscountCouponEndpoint");

        return group;
    }
}