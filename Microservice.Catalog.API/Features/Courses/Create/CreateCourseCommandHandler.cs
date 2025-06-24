namespace Microservice.Catalog.API.Features.Courses.Create;

public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
{
    public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var hasCategory = await context.Categories.AnyAsync(c => c.Id == request.CategoryId, cancellationToken : cancellationToken);

        if (!hasCategory)
        {
            return ServiceResult<Guid>.Error("Category does not exist",$"Category {request.CategoryId} was not found", HttpStatusCode.NotFound);
        }
        
        var hasCourse = await context.Courses.AnyAsync(c => c.Name == request.Name, cancellationToken);

        if (hasCourse)
        {
            return ServiceResult<Guid>.Error("Course already exists",$"The course with name ({request.Name}) already exists", HttpStatusCode.Conflict);
        }

        var newCourse = mapper.Map<Course>(request);
        newCourse.Id = NewId.NextSequentialGuid();
        newCourse.CreatedDateTime = DateTime.Now;
        newCourse.Feature = new Feature()
        {
            Duration = 10, // calculate this by course videos
            EducatorFullName = "John Doe", // get by token payload
            Rating = 0
        };
        
        
        
        context.Courses.Add(newCourse);
        await context.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id,$"/api/courses/{newCourse.Id}");
    }
}