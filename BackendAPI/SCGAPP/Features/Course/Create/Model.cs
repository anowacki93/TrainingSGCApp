using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Create
{
    public class CreateCourseRequest
    {
        public string Name { get; set; }
        public List<EnrollmentModel>? Enrollments { get; set; }
    }

    public class CreateCourseResponse
    {
        public string Message { get; set; }
    }
}
