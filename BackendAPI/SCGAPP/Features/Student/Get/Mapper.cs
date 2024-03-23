using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Student.Get
{
    public class GetStudentMapper : Profile
    {
        public GetStudentMapper() 
        {
            CreateMap<StudentModel, GetStudentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
