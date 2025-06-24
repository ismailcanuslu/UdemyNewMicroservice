using Microservice.Catalog.API.Features.Courses.Create;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.API.Features.Courses.Update;

public static class UpdateCourseCommandEndpoint
{
    public static RouteGroupBuilder UpdateCourseCommandGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPut("/", async (UpdateCourseCommand command, IMediator mediator) =>
                (await mediator.Send(command)).ToGenericResult())
            .AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>()
            .Produces<Guid>(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .MapToApiVersion(1,0)
            .WithName("UpdateCourse");

        return group;
    }
}