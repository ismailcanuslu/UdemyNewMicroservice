using MediatR;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Basket.API.Features.Baskets.AddBasketItem;

public static class AddBasketItemEndpoint
{
    public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/item", async (AddBasketItemCommand command, IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
            .AddEndpointFilter<ValidationFilter<AddBasketItemCommand>>()
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .MapToApiVersion(1,0)
            .WithName("AddBasketItem");

        return group;
    }
}