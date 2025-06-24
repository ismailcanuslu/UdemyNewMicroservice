using Microservice.Catalog.API.Features.Categories.Dtos;

namespace Microservice.Catalog.API.Features.Courses.Dtos;

public record CourseDto(Guid Id, string Name, string Description, decimal Price, string ImageUrl, CategoryDto Category, FeatureDto Feature);
