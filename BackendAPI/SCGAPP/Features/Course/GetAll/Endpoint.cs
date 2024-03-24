using FastEndpoints;
using MongoDB.Bson;
using SCGAPP.Features.Create;
using SCGAPP.Models;
using SCGAPP.Services.Interfaces;

namespace SCGAPP.Features.Course.Get
{
    public class GetAllCourses : EndpointWithoutRequest<List<GetCoursesResponse>>
    {
        private readonly ICourseService _CourseService;
        private readonly AutoMapper.IMapper _mapper;

        public GetAllCourses(ICourseService CourseService, AutoMapper.IMapper mapper)
        {
            _CourseService = CourseService;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("/course/getall");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var CoursesList = await _CourseService.GetAllCourses();
            var response = new List<GetCoursesResponse>();
            if (CoursesList.Count > 0)
            {
                foreach (var Course in CoursesList)
                {
                    var CourseNew = _mapper.Map<GetCoursesResponse>(Course);
                    response.Add(CourseNew);
                }
                await SendAsync(response, 200);
            }
            else
            {
                await SendAsync(new List<GetCoursesResponse>(), 200);
            }
        }
    }
}
