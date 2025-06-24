using Asp.Versioning.Builder;
using Microservice.Catalog.API.Features.Categories.Create;
using Microservice.Catalog.API.Features.Categories.GetAll;
using Microservice.Catalog.API.Features.Categories.GetById;

namespace Microservice.Catalog.API.Features.Categories;

public static class CategoryEndpointExt
{
    public static void AddCategoryGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("/api/v{version:apiVersion}/categories")
            .WithApiVersionSet(apiVersionSet)
            .CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetCategoryByIdGroupItemEndpoint()
            .MapToApiVersion(1,0)
            .WithTags("Categories");
    }
}