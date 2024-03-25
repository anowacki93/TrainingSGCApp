using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Create
{
    public class CreateCourseRequest
    {
        public string Name { get; set; }
        public List<EnrollmentModelRequest>? Enrollments { get; set; }
    }

    public class CreateCourseResponse
    {
        public string Message { get; set; }
    }

    public class EnrollmentModelRequest
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public Grade? Grade { get; set; }
    }
}
