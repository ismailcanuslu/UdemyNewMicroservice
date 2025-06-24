using Microservice.Shared.Extensions;

namespace Microservice.Catalog.API.Features.Courses.Delete;

public static class DeleteCourseCommandEndpoint
{
    public static RouteGroupBuilder DeleteCourseCommandGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}",
                async (IMediator mediator, Guid id) => (await mediator.Send(new DeleteCourseCommand(id)))
                    .ToGenericResult())
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .MapToApiVersion(1,0)
            .WithName("DeleteCourse");
        
        return group;
    }
}