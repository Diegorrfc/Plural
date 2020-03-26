using System;
using System.Collections;
using System.Collections.Generic;
using Plural1.Entities;
using Plural1.ResourceParameters;

namespace Plural1.Services
{
    public interface ICourseLibraryRepository
    {
        IEnumerable<Author> GetAuthors();
        IEnumerable<Course> GetCoursesForAuthor(Guid id);
        Author GetAuthor(Guid id);
        bool AuthorExist(Guid guid);
        Course GetCourse(Guid authorId, Guid courseId);
        IEnumerable<Author> GetAuthors(AuthorResourceParamers authorResourceParamers);
        void CreateAuthor(Author author);
    }
}
