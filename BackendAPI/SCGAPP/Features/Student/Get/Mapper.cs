using AutoMapper;
using MongoDB.Bson;
using SCGAPP.Features.Create;
using SCGAPP.Features.Student.Get;
using SCGAPP.Models;

namespace SCGAPP.Features.Student.Edit
{
    public class GetStudentMapper : Profile
    {
        public GetStudentMapper()
        {
            CreateMap<GetStudentRequest, StudentModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));
            CreateMap<StudentModel, GetStudentResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
