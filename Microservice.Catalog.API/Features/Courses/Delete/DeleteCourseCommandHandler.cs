namespace Microservice.Catalog.API.Features.Courses.Delete;

public class DeleteCourseCommandHandler(AppDbContext context) : IRequestHandler<DeleteCourseCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var existingCourse = await context.Courses.FindAsync([request.Id], cancellationToken);

        if (existingCourse is null)
        {
            return ServiceResult.ErrorAsNotFound();
        }
        
        context.Courses.Remove(existingCourse);
        
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}