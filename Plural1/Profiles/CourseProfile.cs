using System;
using AutoMapper;
using Plural1.Entities;
using Plural1.Models;

namespace Plural1.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();               
        }
    }
}
