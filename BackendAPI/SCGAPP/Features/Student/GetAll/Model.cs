using MongoDB.Bson;

namespace SCGAPP.Features.Student.Get
{
    public class GetStudentsResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}
