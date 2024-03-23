using SCGAPP.Features.Create;
using SCGAPP.Features.Student.Get;
using SCGAPP.Models;

public interface IStudentService
{
    Task<StudentModel> CreateStudentAsync(CreateStudentRequest request);
    Task<GetStudentResponse?> GetById(Guid Id);

    Task<List<GetStudentResponse>> GetAllStudents();
    // Inne metody serwisu
}
