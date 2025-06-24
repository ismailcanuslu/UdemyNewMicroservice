
using Microservice.Catalog.API.Features.Courses.Dtos;

namespace Microservice.Catalog.API.Features.Courses.GetAll;

public class GetAllCoursesQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await context.Courses.ToListAsync(cancellationToken : cancellationToken);
        
        var categories = await context.Categories.ToListAsync(cancellationToken : cancellationToken);

        foreach (var course in courses)
        {
            course.Category = categories.First(c => c.Id == course.CategoryId);
        }
        
        var coursesAsDto = mapper.Map<List<CourseDto>>(courses);
        return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);

    }
}