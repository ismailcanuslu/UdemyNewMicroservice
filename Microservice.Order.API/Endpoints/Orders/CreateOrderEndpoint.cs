using MediatR;
using Microservice.Order.Application.Features.Orders.CreateOrder;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Order.API.Endpoints.Orders;

public static class CreateOrderEndpoint
{
    public static RouteGroupBuilder CreateOrderGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async ([FromBody]CreateOrderCommand command, [FromServices]IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .MapToApiVersion(1,0)
            .AddEndpointFilter<ValidationFilter<CreateOrderCommand>>()
            .WithName("CreateOrder");

        return group;
    }
}