using MongoDB.Bson;
using SCGAPP.Features.Create;
using SCGAPP.Features.Student.Edit;
using SCGAPP.Features.Student.Get;
using SCGAPP.Models;

public interface IStudentService
{
    Task<StudentModel> CreateStudentAsync(StudentModel model);
    Task<StudentModel?> GetById(ObjectId Id);

    Task<List<StudentModel>> GetAllStudents();
    Task<StudentModel> EditStudent(StudentModel model);
    // Inne metody serwisu
}
