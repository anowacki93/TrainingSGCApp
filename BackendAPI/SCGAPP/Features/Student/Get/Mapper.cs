using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Student.Get
{
    public class GetStudentMapper : Profile
    {
        public GetStudentMapper() 
        {
            CreateMap<StudentModel, GetStudentResponse>();
        }
    }
}
