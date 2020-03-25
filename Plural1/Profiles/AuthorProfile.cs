using System;
using AutoMapper;
using Plural1.Entities;
using Plural1.Helpers;
using Plural1.Models;

namespace Plural1.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom( src=> $"{src.FirstName} {src.LastName}")
                )
                .ForMember(des=>des.Age, opt=>opt.MapFrom(src=> src.DateOfBirth.GetCurrentAge()));
        }
    }
}
