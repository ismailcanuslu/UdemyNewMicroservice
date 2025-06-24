using Asp.Versioning.Builder;
using Microservice.Catalog.API.Features.Courses.Create;
using Microservice.Catalog.API.Features.Courses.Delete;
using Microservice.Catalog.API.Features.Courses.GetAll;
using Microservice.Catalog.API.Features.Courses.GetAllByUserId;
using Microservice.Catalog.API.Features.Courses.GetById;
using Microservice.Catalog.API.Features.Courses.Update;


namespace Microservice.Catalog.API.Features.Courses;

public static class CourseEndpointExt
{
    public static void AddCourseGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("/api/v{version:apiVersion}/courses")
            .WithApiVersionSet(apiVersionSet)
            .CreateCourseGroupItemEndpoint()
            .GetAllCoursesGroupItemEndpoint()
            .GetCoursesByIdGroupItemEndpoint()
            .UpdateCourseCommandGroupItemEndpoint()
            .DeleteCourseCommandGroupItemEndpoint()
            .GetAllCoursesByUserIdGroupItemEndpoint()
            .WithTags("Courses");
    }
}