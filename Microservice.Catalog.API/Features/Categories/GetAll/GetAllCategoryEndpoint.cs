using Microservice.Catalog.API.Features.Categories.Dtos;
using Microservice.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.API.Features.Categories.GetAll;

public static class GetAllCategoryEndpoint
{
    public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/" , async (IMediator mediator) => (await mediator.Send(new GetAllCategoryQuery()))
            .ToGenericResult())
            .Produces<List<CategoryDto>>(StatusCodes.Status200OK)
            .MapToApiVersion(1,0)
            .WithName("GetAllCategory");
        
        return group;
    }
}