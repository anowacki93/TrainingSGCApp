using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Create
{
    public class CreateCourseMapper : Profile
    {
        public CreateCourseMapper()
        {
            CreateMap<EnrollmentModelRequest, EnrollmentModel>().ForMember(dest => dest.Grade, opt => opt.Ignore()).ForMember(dest => dest.CourseId, opt => opt.Ignore()); ;
            CreateMap<CreateCourseRequest, CourseModel>(); // Ignore Enrollments during the initial mapping
        }
    }

}
