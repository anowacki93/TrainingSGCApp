using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Create
{
    public class CreateCourseMapper : Profile
    {
        public CreateCourseMapper()
        {
            CreateMap<CreateCourseRequest, CourseModel>();
        }
    }

}
