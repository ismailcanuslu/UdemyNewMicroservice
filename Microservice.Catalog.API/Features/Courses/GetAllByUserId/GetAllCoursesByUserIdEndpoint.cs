using Microservice.Catalog.API.Features.Categories.Dtos;
using Microservice.Catalog.API.Features.Courses.Dtos;
using Microservice.Shared.Extensions;

namespace Microservice.Catalog.API.Features.Courses.GetAllByUserId;

public static class GetAllCoursesByUserIdEndpoint
{
    public static RouteGroupBuilder GetAllCoursesByUserIdGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/user/{userId:guid}" , async (IMediator mediator, Guid userId) => (await mediator.Send(new GetAllCoursesByUserIdQuery(userId)))
                .ToGenericResult())
            .Produces<List<CourseDto>>(StatusCodes.Status200OK)
            .MapToApiVersion(1,0)
            .WithName("GetAllCoursesByUserId");
        
        return group;
    }
}