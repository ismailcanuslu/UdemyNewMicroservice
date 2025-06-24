using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.API.Features.Categories.Create;

public static class CreateCategoryEndpoint
{
    public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) =>
            (await mediator.Send(command)).ToGenericResult())
            .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>()
            .Produces<CreateCategoryResponse>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status409Conflict)
            .MapToApiVersion(1,0)
            .WithName("CreateCategory");

        return group;
    }
}