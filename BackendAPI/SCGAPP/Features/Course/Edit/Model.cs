using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Edit
{
    public class EditCourseRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public List<StudentModel> Courses { get; set; }
    }
    public class EditCourseResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public List<StudentModel> Courses { get; set; }
    }
}
