using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Create
{
    public class CreateCourseRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }
        public List<StudentModel> Students { get; set; }
    }

    public class CreateCourseResponse
    {
        public string Message { get; set; }
    }
}
