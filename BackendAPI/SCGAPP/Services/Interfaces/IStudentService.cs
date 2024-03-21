using SCGAPP.Features.Create;
using SCGAPP.Models;

public interface IStudentService
{
    Task<StudentModel> CreateStudentAsync(CreateStudentRequest request);
    // Inne metody serwisu
}
