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
            CreateMap<CourseModel, GetCourseResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
