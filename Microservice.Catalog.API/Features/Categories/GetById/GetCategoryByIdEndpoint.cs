using Microservice.Catalog.API.Features.Categories.Dtos;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.API.Features.Categories.GetById;

public static class GetCategoryByIdEndpoint
{
    public static RouteGroupBuilder GetCategoryByIdGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}",
            async (IMediator mediator, Guid id) => (await mediator.Send(new GetCategoryByIdQuery(id)))
                .ToGenericResult())
            .Produces<CategoryDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("GetCategoryById");
        
        return group;
    }
}