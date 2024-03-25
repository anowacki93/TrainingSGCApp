using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Get
{
    public class GetCourseRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<EnrollmentModelDTO> Enrollments { get; set; }
    }
    public class GetCourseResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<EnrollmentModelDTO> Enrollments { get; set; }
    }

    public class EnrollmentModelDTO
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public Grade? Grade { get; set; }
    }
}
