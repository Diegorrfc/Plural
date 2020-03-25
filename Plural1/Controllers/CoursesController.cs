using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plural1.Models;
using Plural1.Services;

namespace Plural1.Controllers
{
    [Route("api/courses/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {

        private ICourseLibraryRepository _repository;
        private readonly IMapper _mapper;
      
        public CoursesController(ICourseLibraryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCourseForAuthor(Guid authorId)
        {
            if (!_repository.AuthorExist(authorId))
                return NotFound();

            var coursesFromRepo = _repository.GetCoursesForAuthor(authorId);

            return _mapper.Map<List<CourseDto>>(coursesFromRepo);
        }

        [HttpGet("{courseId}")]
        public ActionResult<CourseDto> GetCourseForAuthor(Guid authorId, Guid courseId)
        {
            if (!_repository.AuthorExist(authorId))
                return NotFound();

            var coursesFromRepo = _repository.GetCourse(authorId, courseId);

            if (coursesFromRepo == null)
                return NotFound();

            return _mapper.Map<CourseDto>(coursesFromRepo);
        }

    }
}
