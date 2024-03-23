using FastEndpoints;
using MongoDB.Bson;
using SCGAPP.Features.Create;

namespace SCGAPP.Features.Student.Get
{
    public class GetStudent : EndpointWithoutRequest<List<GetStudentResponse>>
    {
        private readonly IStudentService _studentService;

        public GetStudent(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Get("/student/getall");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var response = await _studentService.GetAllStudents();
            if (response != null && response.Any())
            {
                await SendAsync(response);
            }
            else
            {
                await SendAsync(new List<GetStudentResponse>());
            }
        }

    }
}
