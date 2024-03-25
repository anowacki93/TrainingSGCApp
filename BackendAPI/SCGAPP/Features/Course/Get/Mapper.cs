using AutoMapper;
using MongoDB.Bson;
using SCGAPP.Features.Course.Get;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Edit
{
    public class GetCourseMapper : Profile
    {
        public GetCourseMapper()
        {
            CreateMap<GetCourseRequest, CourseModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));
            CreateMap<CourseModel, GetCourseResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src =>
                src.Enrollments.Select(enrollment => new EnrollmentModelDTO
                {
                    StudentId = enrollment.StudentId.ToString(),
                    CourseId = enrollment.CourseId.ToString(),
                    Grade = enrollment.Grade
                }).ToList()));

            CreateMap<EnrollmentModel, EnrollmentModelDTO>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId.ToString()))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId.ToString()))
                .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Grade));
        }
    }
}
