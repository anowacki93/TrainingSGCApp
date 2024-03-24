using AutoMapper;
using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Edit
{
    public class EditCourseMapper : Profile
    {
        public EditCourseMapper()
        {
            CreateMap<EditCourseRequest, CourseModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));
            CreateMap<CourseModel, EditCourseResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
