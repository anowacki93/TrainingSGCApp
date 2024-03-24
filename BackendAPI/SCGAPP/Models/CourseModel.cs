using MongoDB.Bson;
using System.Net.NetworkInformation;

namespace SCGAPP.Models
{
    public class CourseModel
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<EnrollmentModel>? Enrollments { get; set; }
    }
}
