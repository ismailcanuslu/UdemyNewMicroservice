using MediatR;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.File.API.Features.File.Upload;

public static class UploadFileCommandEndpoint
{
    public static RouteGroupBuilder UploadFileCommandGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (IFormFile file, IMediator mediator) =>
                (await mediator.Send(new UploadFileCommand(file))).ToGenericResult())
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .MapToApiVersion(1,0)
            .WithName("UploadFile")
            .DisableAntiforgery();

        return group;
    }
}