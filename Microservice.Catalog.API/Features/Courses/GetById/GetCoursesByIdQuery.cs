using Microservice.Catalog.API.Features.Courses.Dtos;

namespace Microservice.Catalog.API.Features.Courses.GetById;

public record GetCoursesByIdQuery(Guid Id) : IRequestByServiceResult<CourseDto>;