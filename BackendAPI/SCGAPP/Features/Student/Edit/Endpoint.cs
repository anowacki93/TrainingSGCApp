using FastEndpoints;
using SCGAPP.Features.Student.Edit;
using SCGAPP.Models;

public class EditStudentEndpoint : Endpoint<EditStudentRequest>
{
    private readonly IStudentService _studentService;
    private readonly AutoMapper.IMapper _mapper;

    public EditStudentEndpoint(IStudentService studentService, AutoMapper.IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Put("/student/edit/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EditStudentRequest request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<StudentModel>(request);

        var editedStudent = await _studentService.EditStudent(student);

        if (editedStudent != null)
        {
            var response = _mapper.Map<EditStudentResponse>(editedStudent);
            await SendAsync(response,200);
        }
        else
        {
            await SendOkAsync(); // Sending OK response if student is not found or not edited
        }
    }
}
