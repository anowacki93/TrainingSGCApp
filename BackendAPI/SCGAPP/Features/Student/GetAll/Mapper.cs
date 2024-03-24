using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Student.Get
{
    public class GetAllStudentsMapper : Profile
    {
        public GetAllStudentsMapper() 
        {
            CreateMap<StudentModel, GetStudentsResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
