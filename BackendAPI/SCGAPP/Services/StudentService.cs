using Amazon.Runtime.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
using SCGAPP.Features.Create;
using SCGAPP.Features.Student.Get;
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

    public async Task<List<GetStudentResponse>> GetAllStudents()
    {
        var studentModelList =  await _studentsCollection.Find(x => true).ToListAsync();
        if (studentModelList != null && studentModelList.Any())
        {
            var studentResponseList = new List<GetStudentResponse>();
            foreach (var student in studentModelList)
            {
                studentResponseList.Add(_mapper.Map<GetStudentResponse>(student));
            }
            return studentResponseList;
        }
        return null;

    }

    public async Task<GetStudentResponse?> GetById(Guid Id)
    {
        var studentModel = await _studentsCollection.Find<StudentModel>(x => x.Id.Equals(Id)).FirstOrDefaultAsync();

        if (studentModel != null)
        {
            // Perform mapping from StudentModel to GetStudentResponse
            var response = _mapper.Map<GetStudentResponse>(studentModel);
            return response;
        }

        return null;
    }

}
