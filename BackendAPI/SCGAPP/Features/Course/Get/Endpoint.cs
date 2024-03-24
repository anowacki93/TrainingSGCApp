using FastEndpoints;
using SCGAPP.Features.Course.Edit;
using SCGAPP.Features.Course.Get;
using SCGAPP.Models;
using SCGAPP.Services.Interfaces;

public class GetCourseEndpoint : Endpoint<GetCourseRequest, GetCourseResponse>
{
    private readonly ICourseService _CourseService;
    private readonly AutoMapper.IMapper _mapper;

    public GetCourseEndpoint(ICourseService CourseService, AutoMapper.IMapper mapper)
    {
        _CourseService = CourseService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Get("/course/get/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCourseRequest request,CancellationToken cancellationToken)
    {
        var Course = _mapper.Map<CourseModel>(request);

        var editedCourse = await _CourseService.GetById(Course.Id);

        if (editedCourse != null)
        {
            var response = _mapper.Map<GetCourseResponse>(editedCourse);
            await SendAsync(response, 200);
        }
        else
        {
            await SendOkAsync(); // Sending OK response if Course is not found or not edited
        }
    }
}
