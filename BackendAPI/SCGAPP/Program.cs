using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using SCGAPP.Features.Create;
using SCGAPP.Models;

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
builder.Services.AddAutoMapper(typeof(StudentMapper));
// Dodaj klienta MongoDB do kontenera DI
builder.Services.AddSingleton<MongoDbContext>(sp => new MongoDbContext(mongoConnectionString, databaseName));
builder.Services.AddSingleton<IMongoCollection<StudentModel>>(sp =>
{
    return database.GetCollection<StudentModel>("students"); // SprawdŸ nazwê kolekcji
});

// Register FastEndpoints
builder.Services.AddFastEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseFastEndpoints();

app.Run();
