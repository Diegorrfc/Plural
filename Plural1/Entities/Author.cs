﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plural1.Entities
{
    public class Author
    {
        public Author()
        {
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string MainCategory { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
