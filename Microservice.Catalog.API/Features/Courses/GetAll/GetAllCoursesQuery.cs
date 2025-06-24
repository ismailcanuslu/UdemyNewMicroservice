
using Microservice.Catalog.API.Features.Courses.Dtos;

namespace Microservice.Catalog.API.Features.Courses.GetAll;

public record GetAllCoursesQuery: IRequestByServiceResult<List<CourseDto>>;