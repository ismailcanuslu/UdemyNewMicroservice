using Microservice.Catalog.API.Features.Categories.Dtos;

namespace Microservice.Catalog.API.Features.Categories.GetAll;

public record GetAllCategoryQuery: IRequestByServiceResult<List<CategoryDto>>;