using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Get
{
    public class GetAllCoursesMapper : Profile
    {
        public GetAllCoursesMapper() 
        {
            CreateMap<CourseModel, GetCoursesResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
