using Microservice.Catalog.API.Features.Categories.Dtos;

namespace Microservice.Catalog.API.Features.Categories.GetById;

public record GetCategoryByIdQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;
