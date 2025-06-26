using MediatR;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Basket.API.Features.Baskets.DeleteBasketItem;

public static class DeleteBasketItemEndpoint
{
    public static RouteGroupBuilder DeleteBasketItemGroupEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/item/{id:guid}", async (Guid id, IMediator mediator) =>
                (await mediator.Send(new DeleteBasketItemCommand(id))).ToGenericResult())
            .AddEndpointFilter<ValidationFilter<DeleteBasketItemCommandValidator>>()
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .MapToApiVersion(1,0)
            .WithName("DeleteBasketItem");

        return group;
    }
}