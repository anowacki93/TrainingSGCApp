using MongoDB.Bson;

namespace SCGAPP.Models
{
    public class EnrollmentModel
    {
        public ObjectId StudentId { get; set; }
        public ObjectId CourseId { get; set; }
        public Grade? Grade { get; set; }
    }

    public enum Grade
    {
        None = 0,
        Niedostateczny = 1,
        Dopuszcający = 2,
        Dostateczny = 3,
        Dobra = 4,
        Bardzo_dobra = 5,
        Celująca = 6
    }
}
