using AutoMapper;
using MongoDB.Bson;
using SCGAPP.Features.Create;
using SCGAPP.Models;

namespace SCGAPP.Features.Student.Edit
{
    public class EditStudentMapper : Profile
    {
        public EditStudentMapper()
        {
            CreateMap<EditStudentRequest, StudentModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));
            CreateMap<StudentModel, EditStudentResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
