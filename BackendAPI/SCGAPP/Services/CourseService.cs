using Amazon.Runtime.Internal;
using MongoDB.Bson;
using MongoDB.Driver;

using SCGAPP.Features.Course.Edit;
using SCGAPP.Features.Course.Get;
using SCGAPP.Models;
using SCGAPP.Services.Interfaces;

public class CourseService : ICourseService
{
    private readonly IMongoCollection<CourseModel> _coursesCollection;
    private readonly IMongoCollection<StudentModel> _studentsCollection;

    public CourseService(IMongoCollection<CourseModel> coursesCollection, IMongoCollection<StudentModel> studentsCollection)
    {
        _coursesCollection = coursesCollection;
        _studentsCollection = studentsCollection;
    }

    public async Task<CourseModel> CreateCourseAsync(CourseModel request)
    {
        request.Id = ObjectId.GenerateNewId();
        request.Enrollments = request.Enrollments?.Where(e => e.StudentId != ObjectId.Empty).ToList();
        if(request.Enrollments.Where(e => e.StudentId != ObjectId.Empty).Any() == true)
        {
            foreach(var e in request.Enrollments)
            {
                e.CourseId = request.Id;
                e.Grade = Grade.None;
            }
        }
        await _coursesCollection.InsertOneAsync(request);
        return request;
    }

    public async Task<CourseModel> EditCourse(CourseModel course)
    {
        var existingCourse = await GetById(course.Id);
        if (existingCourse != null)
        {
            var filter = Builders<CourseModel>.Filter.Eq("_id", existingCourse.Id);
            var update = Builders<CourseModel>.Update
                .Set("Name", course.Name);

            // Optional: Handle enrollment updates
            if (course.Enrollments != null && course.Enrollments.Any())
            {
                // Merge existing and new enrollments to prevent overwriting
                var updatedEnrollments = existingCourse.Enrollments.Concat(course.Enrollments)
                    .GroupBy(e => new { e.StudentId, e.CourseId })
                    .Select(g => g.Last())
                    .ToList();

                update = update.Set("Enrollments", updatedEnrollments);
            }

            await _coursesCollection.UpdateOneAsync(filter, update);

            return course;
        }
        return null;
    }



    public async Task<List<CourseModel>> GetAllCourses()
    {
        return await _coursesCollection.Find(x => true).ToListAsync();
    }

    public async Task<CourseModel?> GetById(ObjectId Id)
    {
        return await _coursesCollection.Find<CourseModel>(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
    }

}
