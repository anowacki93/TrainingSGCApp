using Amazon.Runtime.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
using SCGAPP.Features.Create;
using SCGAPP.Features.Student.Edit;
using SCGAPP.Features.Student.Get;
using SCGAPP.Models;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<StudentModel> _studentsCollection;

    public StudentService(IMongoCollection<StudentModel> studentsCollection)
    {
        _studentsCollection = studentsCollection;
    }

    public async Task<StudentModel> CreateStudentAsync(StudentModel request)
    {
        var studentModel = new StudentModel();
        studentModel.Id = ObjectId.GenerateNewId();
        await _studentsCollection.InsertOneAsync(studentModel);
        return studentModel;
    }

    public async Task<StudentModel> EditStudent(StudentModel student)
    {
        var existingStudent = await GetById(student.Id);
        if (existingStudent != null)
        {
            var filter = Builders<StudentModel>.Filter.Eq("_id", existingStudent.Id);
            var update = Builders<StudentModel>.Update
                .Set("FirstName", student.FirstName)
                .Set("LastName", student.LastName)
                .Set("Age", student.Age);

            await _studentsCollection.UpdateOneAsync(filter, update);

            return student;
        }
        return null;
    }

    public async Task<List<StudentModel>> GetAllStudents()
    {
        return await _studentsCollection.Find(x => true).ToListAsync();
    }

    public async Task<StudentModel?> GetById(ObjectId Id)
    {
        return await _studentsCollection.Find<StudentModel>(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
    }

}
