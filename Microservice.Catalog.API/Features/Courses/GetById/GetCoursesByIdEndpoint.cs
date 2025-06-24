using Microservice.Catalog.API.Features.Courses.Dtos;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.API.Features.Courses.GetById;

public static class GetCoursesByIdEndpoint
{
    public static RouteGroupBuilder GetCoursesByIdGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}",
                async (IMediator mediator, Guid id) => (await mediator.Send(new GetCoursesByIdQuery(id)))
                    .ToGenericResult())
            .Produces<CourseDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .MapToApiVersion(1,0)
            .WithName("GetCoursesById");
        
        return group;
    }
}