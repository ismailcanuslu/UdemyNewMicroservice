using Microservice.Catalog.API.Features.Courses.Dtos;

namespace Microservice.Catalog.API.Features.Courses.GetAllByUserId;

public record GetAllCoursesByUserIdQuery(Guid Id) : IRequestByServiceResult<List<CourseDto>>;