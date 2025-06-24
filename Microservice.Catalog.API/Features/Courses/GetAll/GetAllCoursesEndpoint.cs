
using Microservice.Catalog.API.Features.Courses.Dtos;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.API.Features.Courses.GetAll;

public static class GetAllCoursesEndpoint
{
    public static RouteGroupBuilder GetAllCoursesGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/" , async (IMediator mediator) => (await mediator.Send(new GetAllCoursesQuery()))
            .ToGenericResult())
            .Produces<List<CourseDto>>(StatusCodes.Status200OK)
            .MapToApiVersion(1,0)
            .WithName("GetAllCourses");
        
        return group;
    }
}