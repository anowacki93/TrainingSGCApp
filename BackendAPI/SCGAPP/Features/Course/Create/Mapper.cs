using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Create
{
    public class CreateCourseMapper : Profile
    {
        public CreateCourseMapper()
        {
            CreateMap<CourseModel, CreateCourseRequest>();
        }
    }

}
