using FastEndpoints;
using SCGAPP.Features.Course.Edit;
using SCGAPP.Models;
using SCGAPP.Services.Interfaces;

public class EditCourseEndpoint : Endpoint<EditCourseRequest>
{
    private readonly ICourseService _CourseService;
    private readonly AutoMapper.IMapper _mapper;

    public EditCourseEndpoint(ICourseService CourseService, AutoMapper.IMapper mapper)
    {
        _CourseService = CourseService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Put("/course/edit/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(EditCourseRequest request, CancellationToken cancellationToken)
    {
        var Course = _mapper.Map<CourseModel>(request);

        var editedCourse = await _CourseService.EditCourse(Course);

        if (editedCourse != null)
        {
            var response = _mapper.Map<EditCourseResponse>(editedCourse);
            await SendAsync(response,200);
        }
        else
        {
            await SendOkAsync(); // Sending OK response if Course is not found or not edited
        }
    }
}
