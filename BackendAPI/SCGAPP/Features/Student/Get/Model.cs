using MongoDB.Bson;

namespace SCGAPP.Features.Student.Get
{
    public class GetStudentResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ObjectId Id { get; set; }
    }
}
