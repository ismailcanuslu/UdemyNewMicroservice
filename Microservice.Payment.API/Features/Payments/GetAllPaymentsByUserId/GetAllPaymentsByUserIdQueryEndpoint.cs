using MediatR;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Payment.API.Features.Payments.GetAllPaymentsByUserId;

public static class GetAllPaymentsByUserIdQueryEndpoint
{
    public static RouteGroupBuilder GetAllPaymentsCommandGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) =>
            (await mediator.Send(new GetAllPaymentsByUserIdQuery())).ToGenericResult())
            .Produces<List<GetAllPaymentsByUserIdResponse>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .MapToApiVersion(1,0)
            .WithName("GetAllPaymentsByUserId");

        return group;
    }
}