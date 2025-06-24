using Microservice.Catalog.API.Features.Courses.Create;
using Microservice.Catalog.API.Features.Courses.Dtos;
using Microservice.Catalog.API.Features.Courses.Update;

namespace Microservice.Catalog.API.Features.Courses;

public class CourseMapping : Profile
{
    public CourseMapping()
    {
        CreateMap<CreateCourseCommand, Course>();
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Feature,FeatureDto>().ReverseMap();
        CreateMap<UpdateCourseCommand, Course>();
    }
}