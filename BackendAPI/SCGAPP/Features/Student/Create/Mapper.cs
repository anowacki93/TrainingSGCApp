using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Student.Create
{
    public class CreateStudentMapper : Profile
    {
        public CreateStudentMapper()
        {
            CreateMap<CreateStudentRequest, StudentModel>();
        }
    }

}
