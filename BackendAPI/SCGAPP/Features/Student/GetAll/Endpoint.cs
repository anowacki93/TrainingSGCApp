﻿using FastEndpoints;
using MongoDB.Bson;
using SCGAPP.Models;

namespace SCGAPP.Features.Student.Get
{
    public class GetAllStudents : EndpointWithoutRequest<List<GetStudentsResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly AutoMapper.IMapper _mapper;

        public GetAllStudents(IStudentService studentService, AutoMapper.IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Get("/student/getall");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var studentsList = await _studentService.GetAllStudents();
            var response = new List<GetStudentsResponse>();
            if (studentsList.Count > 0)
            {
                foreach (var student in studentsList)
                {
                    var studentNew = _mapper.Map<GetStudentsResponse>(student);
                    response.Add(studentNew);
                }
                await SendAsync(response, 200);
            }
            else
            {
                await SendAsync(new List<GetStudentsResponse>(), 200);
            }
        }
    }
}
