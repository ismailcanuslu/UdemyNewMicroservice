namespace Microservice.Catalog.API.Features.Courses.Delete;

public record DeleteCourseCommand(Guid Id) : IRequestByServiceResult;
