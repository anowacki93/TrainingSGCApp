namespace SCGAPP.Features.Student.Get
{
    public class GetStudentRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
    public class GetStudentResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
