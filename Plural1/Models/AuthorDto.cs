using System;
namespace Plural1.Models
{
    public class AuthorDto
    {
        public AuthorDto()
        {
        }

        public Guid Id { get; set; }
       
        public string Name { get; set; }      
        
        public int Age { get; set; }
        
        public string MainCategory { get; set; }

        //public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
