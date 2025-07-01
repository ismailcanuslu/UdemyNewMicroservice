using MediatR;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Payment.API.Features.Payments.Create;

public static class CreatePaymentCommandEndpoint
{
    public static RouteGroupBuilder CreatePaymentCommandGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async ([FromBody]CreatePaymentCommand command, [FromServices]IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
            .AddEndpointFilter<ValidationFilter<CreatePaymentCommand>>()
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .MapToApiVersion(1,0)
            .WithName("CreatePayment");

        return group;
    }
}