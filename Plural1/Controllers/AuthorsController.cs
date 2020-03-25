using System;
using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthor()
        {
           var authorsFromRepository = _repository.GetAuthors();

           
           List<AuthorDto>  authorsDto = _mapper.Map<List<AuthorDto>>(authorsFromRepository);

           return Ok(authorsDto);
        }
    }
}
