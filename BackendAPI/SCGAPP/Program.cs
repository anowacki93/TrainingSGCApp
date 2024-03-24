using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using SCGAPP.Features.Course.Create;
using SCGAPP.Features.Course.Edit;
using SCGAPP.Features.Course.Get;
using SCGAPP.Features.Student.Create;
using SCGAPP.Features.Student.Edit;
using SCGAPP.Features.Student.Get;
using SCGAPP.Models;
using SCGAPP.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Konfiguracja po³¹czenia z MongoDB
var configuration = builder.Configuration;
var mongoConnectionString = configuration.GetConnectionString("MongoDB");
var mongoClient = new MongoClient(mongoConnectionString);
var databaseName = "SGCDB"; // Nazwa twojej bazy danych MongoDB
var database = mongoClient.GetDatabase(databaseName);
builder.Services.AddAutoMapper(typeof(CreateStudentMapper));
builder.Services.AddAutoMapper(typeof(GetStudentMapper));
builder.Services.AddAutoMapper(typeof(GetAllStudentsMapper));
builder.Services.AddAutoMapper(typeof(EditStudentMapper));
builder.Services.AddAutoMapper(typeof(CreateCourseMapper));
builder.Services.AddAutoMapper(typeof(GetCourseMapper));
builder.Services.AddAutoMapper(typeof(GetAllCoursesMapper));
builder.Services.AddAutoMapper(typeof(EditCourseMapper));
// Dodaj klienta MongoDB do kontenera DI
builder.Services.AddSingleton<MongoDbContext>(sp => new MongoDbContext(mongoConnectionString, databaseName));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddSingleton<IMongoCollection<StudentModel>>(sp =>
{
    return database.GetCollection<StudentModel>("students");
});

builder.Services.AddSingleton<IMongoCollection<CourseModel>>(sp =>
{
    return database.GetCollection<CourseModel>("courses");
});

builder.Services.AddSingleton<IMongoCollection<EnrollmentModel>>(sp =>
{
    return database.GetCollection<EnrollmentModel>("enrollments");
});


// Register FastEndpoints
builder.Services.AddFastEndpoints();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AllowAnyOrigin");


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseFastEndpoints();

app.Run();
