﻿using System;
namespace Plural1.Models
{
    public class AuthorForCreationDto
    {
        public AuthorForCreationDto()
        {
        }
       
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        
        public DateTimeOffset DateOfBirth { get; set; }
        
        public string MainCategory { get; set; }

    }
}
