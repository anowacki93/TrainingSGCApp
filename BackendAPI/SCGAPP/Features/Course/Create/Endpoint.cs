using AutoMapper;
using FastEndpoints;
using MongoDB.Driver;
using SCGAPP.Features.Create;
using SCGAPP.Models;
using SCGAPP.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

public class CreateCourseEndpoint : Endpoint<CreateCourseRequest, CreateCourseResponse>
{
    private readonly ICourseService _CourseService;
    private readonly AutoMapper.IMapper _mapper;

    public CreateCourseEndpoint(ICourseService CourseService, AutoMapper.IMapper mapper)
    {
        _CourseService = CourseService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Post("/Course/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCourseRequest request, CancellationToken cancellationToken)
    {
       var Course = _mapper.Map<CourseModel>(request);
        await _CourseService.CreateCourseAsync(Course);

        await SendAsync(new CreateCourseResponse
        {
            Message = "Course created successfully",
        });
    }
}
