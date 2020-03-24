using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Plural1.Helpers;
using Plural1.Models;
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

        [HttpGet()]
        public IActionResult GetAuthor()
        {
           var authorsFromRepository = _repository.GetAuthors();
            var authorsDto = new List<AuthorDto>();

            foreach (var item in authorsFromRepository)
            {
                authorsDto.Add(new AuthorDto()
                {
                      Name = $"{ item.FirstName}{item.LastName}",
                       MainCategory = item.MainCategory,
                       Id = item.Id,
                       Age = item.DateOfBirth.GetCurrentAge()
                });
            }
           return Ok(authorsFromRepository);
        }
    }
}
