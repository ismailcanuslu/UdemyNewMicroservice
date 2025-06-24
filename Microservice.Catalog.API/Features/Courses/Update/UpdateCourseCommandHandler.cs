namespace Microservice.Catalog.API.Features.Courses.Update;

public class UpdateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<UpdateCourseCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var existingCourse = await context.Courses.FindAsync([request.Id], cancellationToken);

        if (existingCourse is null)
        {
            return ServiceResult.ErrorAsNotFound();
        }
        
        mapper.Map(request, existingCourse);
        
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}