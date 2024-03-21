using MongoDB.Bson;
using MongoDB.Driver;
using SCGAPP.Features.Create;
using SCGAPP.Models;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<StudentModel> _studentsCollection;
    private readonly AutoMapper.IMapper _mapper;

    public StudentService(IMongoCollection<StudentModel> studentsCollection, AutoMapper.IMapper mapper)
    {
        _studentsCollection = studentsCollection;
        _mapper = mapper;
    }

    public async Task<StudentModel> CreateStudentAsync(CreateStudentRequest request)
    {
        var studentModel = _mapper.Map<StudentModel>(request);
        studentModel.Id = ObjectId.GenerateNewId();
        await _studentsCollection.InsertOneAsync(studentModel);
        return studentModel;
    }
}
