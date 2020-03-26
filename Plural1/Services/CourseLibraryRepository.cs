using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Plural1.Context;
using Plural1.Entities;
using Plural1.ResourceParameters;

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
        public IEnumerable<Course> GetCoursesForAuthor(Guid id)
        {
            return _Context.Courses.Where(c => c.AuthorId == id).ToList();
        }
        public bool AuthorExist(Guid guid)
        {
            return _Context.Authors.Find(guid) != null;
        }
        public Course GetCourse(Guid authorId, Guid courseId)
        {
            return _Context.Courses.FirstOrDefault(n => n.AuthorId == authorId && n.Id == courseId);
        }
        private void Dispose(bool v)
        {
           
        }

        public IEnumerable<Author> GetAuthors(AuthorResourceParamers authorResourceParamers)
        {
            var collection = _Context.Authors as IQueryable<Author>;

            if (!string.IsNullOrEmpty(authorResourceParamers.MainCategory))
            {
                collection = collection.Where(n => n.MainCategory == authorResourceParamers.MainCategory.Trim());
            }
            if (!string.IsNullOrEmpty(authorResourceParamers.FirstName))
                collection = collection.Where(n => n.FirstName.Contains(authorResourceParamers.FirstName));

            return collection.ToList();
            
        }

        public Author GetAuthor(Guid id)
        {
            throw new NotImplementedException();
        }
        public void AddCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void CreateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        ~CourseLibraryRepository()
        {
            
        }
        public CourseLibraryRepository()
        {

        }
    }
}
