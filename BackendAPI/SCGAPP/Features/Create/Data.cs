using MongoDB.Bson;

namespace SCGAPP.Features.Create
{
    public class CreateStudentRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class CreateStudentResponse
    {
        public string Message { get; set; }
    }

}
