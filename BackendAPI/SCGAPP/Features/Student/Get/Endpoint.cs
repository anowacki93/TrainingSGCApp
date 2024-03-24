using FastEndpoints;
using SCGAPP.Features.Create;
using SCGAPP.Features.Student.Edit;
using SCGAPP.Features.Student.Get;
using SCGAPP.Models;

public class GetStudentEndpoint : Endpoint<GetStudentRequest, GetStudentResponse>
{
    private readonly IStudentService _studentService;
    private readonly AutoMapper.IMapper _mapper;

    public GetStudentEndpoint(IStudentService studentService, AutoMapper.IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Get("/student/get/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetStudentRequest request,CancellationToken cancellationToken)
    {
        var student = _mapper.Map<StudentModel>(request);

        var editedStudent = await _studentService.GetById(student.Id);

        if (editedStudent != null)
        {
            var response = _mapper.Map<GetStudentResponse>(editedStudent);
            await SendAsync(response, 200);
        }
        else
        {
            await SendOkAsync(); // Sending OK response if student is not found or not edited
        }
    }
}
