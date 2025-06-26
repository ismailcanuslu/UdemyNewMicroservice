using MediatR;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Basket.API.Features.Baskets.GetBasket;

public static class GetBasketQueryEndpoint
{
    public static RouteGroupBuilder GetBasketQueryGroupEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/user", async (IMediator mediator) =>
                (await mediator.Send(new GetBasketQuery())).ToGenericResult())
            .Produces(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .MapToApiVersion(1,0)
            .WithName("GetBasketItem");

        return group;
    }
}