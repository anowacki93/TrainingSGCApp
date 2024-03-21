using AutoMapper;
using FastEndpoints;
using MongoDB.Driver;
using SCGAPP.Features.Create;
using SCGAPP.Models;
using System.Threading;
using System.Threading.Tasks;

public class CreateStudentEndpoint : Endpoint<CreateStudentRequest, CreateStudentResponse>
{
    private readonly IStudentService _studentService;

    public CreateStudentEndpoint(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public override void Configure()
    {
        Post("/student/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateStudentRequest request, CancellationToken cancellationToken)
    {

        var createdStudent = await _studentService.CreateStudentAsync(request);

        await SendAsync(new CreateStudentResponse
        {
            Message = "Student created successfully",
        });
    }
}
