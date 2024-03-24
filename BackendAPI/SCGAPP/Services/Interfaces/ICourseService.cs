using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Services.Interfaces
{
    public interface ICourseService
    {
        Task<CourseModel> CreateCourseAsync(CourseModel model);
        Task<CourseModel?> GetById(ObjectId Id);

        Task<List<CourseModel>> GetAllCourses();
        Task<CourseModel> EditCourse(CourseModel model);
    }
}
