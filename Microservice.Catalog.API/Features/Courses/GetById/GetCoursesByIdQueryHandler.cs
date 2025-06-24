using Microservice.Catalog.API.Features.Courses.Dtos;

namespace Microservice.Catalog.API.Features.Courses.GetById;

public class GetCoursesByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCoursesByIdQuery, ServiceResult<CourseDto>>
{
    public async Task<ServiceResult<CourseDto>> Handle(GetCoursesByIdQuery request, CancellationToken cancellationToken)
    {
        var existingCourse = await context.Courses.FindAsync([request.Id], cancellationToken);

        if (existingCourse is null)
        {
            return ServiceResult<CourseDto>.Error("Course not found", $"Course with id: {request.Id} was not found", HttpStatusCode.NotFound);
        }
        
        return ServiceResult<CourseDto>.SuccessAsOk(mapper.Map<CourseDto>(existingCourse));
    }
}