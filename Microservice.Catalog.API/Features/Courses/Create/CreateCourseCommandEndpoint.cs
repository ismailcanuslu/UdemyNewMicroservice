using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.API.Features.Courses.Create;

public static class CreateCourseCommandEndpoint
{
    public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCourseCommand command, IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
            .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>()
            .Produces<Guid>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status409Conflict)
            .MapToApiVersion(1,0)
            .WithName("CreateCourse");

        return group;
    }
}