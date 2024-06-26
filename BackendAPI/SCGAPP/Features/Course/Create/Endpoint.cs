﻿using AutoMapper;
using FastEndpoints;
using MongoDB.Bson;
using MongoDB.Driver;
using SCGAPP.Models;
using SCGAPP.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SCGAPP.Features.Course.Create
{
    public class CreateCourseEndpoint : Endpoint<CreateCourseRequest, CreateCourseResponse>
    {
        private readonly ICourseService _CourseService;
        private readonly AutoMapper.IMapper _mapper;

        public CreateCourseEndpoint(ICourseService CourseService, AutoMapper.IMapper mapper)
        {
            _CourseService = CourseService;
            _mapper = mapper;
        }

        public override void Configure()
        {
            Post("/course/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<CourseModel>(request);

            await _CourseService.CreateCourseAsync(course);

            await SendAsync(new CreateCourseResponse
            {
                Message = "Course created successfully",
            });
        }

    }
}

