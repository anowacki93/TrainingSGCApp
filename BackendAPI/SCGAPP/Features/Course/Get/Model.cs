using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Course.Get
{
    public class GetCourseRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public List<StudentModel> Students { get; set; }
    }
    public class GetCourseResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
