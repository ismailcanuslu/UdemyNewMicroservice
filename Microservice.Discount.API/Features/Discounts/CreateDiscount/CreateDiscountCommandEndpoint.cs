using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Discount.API.Features.Discounts.CreateDiscount;

public static class CreateDiscountCommandEndpoint
{
    public static RouteGroupBuilder CreateDiscountCommandGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateDiscountCommand command, IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
            .AddEndpointFilter<ValidationFilter<CreateDiscountCommand>>()
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .MapToApiVersion(1,0)
            .WithName("CreateDiscount");

        return group;
    }
}