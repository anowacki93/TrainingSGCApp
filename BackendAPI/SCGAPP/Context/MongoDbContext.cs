using MongoDB.Driver;
using SCGAPP.Models;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<StudentModel> Students => _database.GetCollection<StudentModel>("students");
    public IMongoCollection<CourseModel> Courses => _database.GetCollection<CourseModel>("courses");
    public IMongoCollection<EnrollmentModel> Enrollments => _database.GetCollection<EnrollmentModel>("enrollments");
}