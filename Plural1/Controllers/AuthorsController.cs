using System;
using Microsoft.AspNetCore.Mvc;
using Plural1.Services;

namespace Plural1.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private ICourseLibraryRepository _repository;

        public AuthorsController(ICourseLibraryRepository repository)
        {
            _repository = repository;
        }
               
        public IActionResult GetAuthor()
        {
           var authorsFromRepository = _repository.GetAuthors();
           return new JsonResult(authorsFromRepository);
        }
    }
}
