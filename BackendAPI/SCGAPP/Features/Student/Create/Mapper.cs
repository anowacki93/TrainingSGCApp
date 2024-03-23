using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Create
{
    public class CreateStudentMapper : Profile
    {
        public CreateStudentMapper()
        {
            CreateMap<CreateStudentRequest, StudentModel>();
        }


    }

}
