using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Edit
{
    public class EditCourseRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<EnrollmentModel> Enrollments { get; set; }
    }
    public class EditCourseResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<EnrollmentModel> Enrollments { get; set; }
    }
}
