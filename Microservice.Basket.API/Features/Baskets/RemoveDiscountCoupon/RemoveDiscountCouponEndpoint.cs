using MediatR;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Basket.API.Features.Baskets.RemoveDiscountCoupon;

public static class RemoveDiscountCouponEndpoint
{
    public static RouteGroupBuilder RemoveDiscountCouponGroupEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("remove-discount-coupon", async (IMediator mediator) =>
                (await mediator.Send(new RemoveDiscountCouponCommand())).ToGenericResult())
            .Produces(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .MapToApiVersion(1,0)
            .WithName("RemoveDiscountCoupon");

        return group;
    }
}