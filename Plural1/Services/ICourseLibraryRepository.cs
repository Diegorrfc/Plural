using System;
using System.Collections;
using System.Collections.Generic;
using Plural1.Entities;

namespace Plural1.Services
{
    public interface ICourseLibraryRepository
    {
        IEnumerable<Author> GetAuthors();
        IEnumerable<Course> GetCoursesForAuthor(Guid id);
        bool AuthorExist(Guid guid);
        Course GetCourse(Guid authorId, Guid courseId);
    }
}
