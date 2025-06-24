using Microservice.Catalog.API.Features.Courses.Dtos;

namespace Microservice.Catalog.API.Features.Courses.GetAllByUserId;

public class GetAllCoursesByUserIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCoursesByUserIdQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var foundedCourses = await context.Courses.Where(x => x.UserId==request.Id)
            .ToListAsync(cancellationToken);
        
        var allCategories = await context.Categories.ToListAsync(cancellationToken);

        foreach (var course in foundedCourses)
        {
            course.Category = allCategories.First(x => x.Id == course.CategoryId);
        }
        
        var coursesAsDto = mapper.Map<List<CourseDto>>(foundedCourses);

        return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);
    }
}