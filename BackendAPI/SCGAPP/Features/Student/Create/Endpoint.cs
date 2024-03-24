using AutoMapper;
using FastEndpoints;
using MongoDB.Bson;
using MongoDB.Driver;
using SCGAPP.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SCGAPP.Features.Student.Create
{
    public class CreateStudentEndpoint : Endpoint<CreateStudentRequest, CreateStudentResponse>
    {
        private readonly IStudentService _studentService;
        private readonly AutoMapper.IMapper _mapper;

        public CreateStudentEndpoint(IStudentService studentService, AutoMapper.IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Post("/student/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateStudentRequest request, CancellationToken cancellationToken)
        {
           var student = _mapper.Map<StudentModel>(request);
            await _studentService.CreateStudentAsync(student);

            await SendAsync(new CreateStudentResponse
            {
                Message = "Student created successfully",
            });
        }
    }
}

