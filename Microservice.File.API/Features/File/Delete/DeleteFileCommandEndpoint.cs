using MediatR;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.File.API.Features.File.Delete;

public static class DeleteFileCommandEndpoint
{
    public static RouteGroupBuilder DeleteFileCommandGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/", async (DeleteFileCommand command , IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .MapToApiVersion(1,0)
            .WithName("DeleteFile")
            .DisableAntiforgery();

        return group;
    }
}