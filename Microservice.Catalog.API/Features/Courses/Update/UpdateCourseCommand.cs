namespace Microservice.Catalog.API.Features.Courses.Update;

public record UpdateCourseCommand(
    Guid Id, 
    string Name, 
    string Description, 
    decimal Price,
    string? imageUrl ,
    Guid CategoryId) : IRequestByServiceResult;