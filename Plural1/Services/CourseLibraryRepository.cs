using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Plural1.Context;
using Plural1.Entities;

namespace Plural1.Services
{
    public class CourseLibraryRepository : ICourseLibraryRepository, IDisposable
    {
        private readonly CourseLibraryContext _Context;
        public CourseLibraryRepository(CourseLibraryContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCourse(Guid authorId, Course course)
        {
            if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

            if (course == null) throw new ArgumentNullException(nameof(course));

            course.AuthorId = authorId;
            _Context.Add(course);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);           
        }
        public IEnumerable<Author> GetAuthors()
        {
           return _Context.Authors.ToList();
        }
        private void Dispose(bool v)
        {
           
        }
        ~CourseLibraryRepository()
        {
            
        }
        public CourseLibraryRepository()
        {

        }
    }
}
