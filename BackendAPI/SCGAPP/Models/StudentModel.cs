﻿using MongoDB.Bson;
using System.Runtime.Serialization;

namespace SCGAPP.Models
{
    public class StudentModel
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
