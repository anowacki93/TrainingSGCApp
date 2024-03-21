using AutoMapper;
using SCGAPP.Models;

namespace SCGAPP.Features.Create
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<CreateStudentRequest, StudentModel>();
        }
    }

}
